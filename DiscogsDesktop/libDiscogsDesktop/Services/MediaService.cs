using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using libDiscogsDesktop.Helper;
using libDiscogsDesktop.Tasks;
using TagLib;
using File = System.IO.File;

namespace libDiscogsDesktop.Services
{
    public static class MediaService
    {
        #region constants

        public const string SuccessSuffix = "_success";

        public const string FailureSuffix = "_failure";

        public const string ImageExtension = ".bmp";

        public const string VideoExtension = ".mp4";

        public const string AudioExtension = ".mp3";

        #endregion

        #region public properties

        public static string ApplicationFolder { get; private set; }

        public static string VideoFolder => Path.Combine(ApplicationFolder ?? "", "Videos");

        public static string AudioFolder => Path.Combine(ApplicationFolder ?? "", "Audios");

        public static string ImageFolder => Path.Combine(ApplicationFolder ?? "", "Images");

        #endregion

        public static void SetApplicationFolder(string folder)
        {
            ApplicationFolder = folder;

            if (!Directory.Exists(VideoFolder))
            {
                Directory.CreateDirectory(VideoFolder);
            }

            if (!Directory.Exists(ImageFolder))
            {
                Directory.CreateDirectory(ImageFolder);
            }
        }

        public static void DeleteFiles(Action<int> progressPercentageCallback = null)
        {
            try
            {
                string[] files = Directory.GetFiles(VideoFolder)
                    .Concat(Directory.GetFiles(ImageFolder))
                    .Concat(Directory.GetFiles(AudioFolder)).ToArray();

                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        File.Delete(files[i]);
                        progressPercentageCallback?.Invoke(ProgressHelper.GetProgressPercentage(i + 1, files.Length));
                    }
                    catch
                    {
                        //ignore
                    }
                }

                progressPercentageCallback?.Invoke(100);
            }
            catch
            {
                //ignore
            }
        }

        public static bool GetVideoFilePath(string youtubeUrl, out string path, TaskProgressReporter reporter)
        {
            ensureExistingDirectory(VideoFolder);

            path = downloadedVideoPath(youtubeUrl);

            if (inDownloadingProgress.ContainsKey(youtubeUrl))
            {
                while (path == null)
                {
                    Thread.Sleep(200);
                    path = downloadedVideoPath(youtubeUrl);
                }

                while (inDownloadingProgress.ContainsKey(youtubeUrl))
                {
                    inDownloadingProgress.TryRemove(youtubeUrl, out _);
                }
            }

            if (path != null)
            {
                return path.Contains(SuccessSuffix);
            }

            getVideoFilePath(youtubeUrl, out path, out string failurePath);

            bool downloaded = YoutubeService.DownloadVideoViaYoutubeExplode(youtubeUrl, path, failurePath, reporter);

            if (!downloaded)
            {
                path = failurePath;
            }

            while (inDownloadingProgress.ContainsKey(youtubeUrl))
            {
                inDownloadingProgress.TryRemove(youtubeUrl, out _);
            }

            return downloaded;
        }
        
        public static bool GetAudioFilePath(string youtubeUrl, out string path)
        {
            ensureExistingDirectory(AudioFolder);

            path = downloadedAudioPath(youtubeUrl);

            if (inConvertingProgress.ContainsKey(youtubeUrl))
            {
                while (path == null)
                {
                    Thread.Sleep(200);
                    path = downloadedAudioPath(youtubeUrl);
                }

                while (inConvertingProgress.ContainsKey(youtubeUrl))
                {
                    inConvertingProgress.TryRemove(youtubeUrl, out _);
                }
            }

            if (path != null)
            {
                return path.Contains(SuccessSuffix);
            }

            getAudioFilePath(youtubeUrl, out path, out string failurePath);

            if (!GetVideoFilePath(youtubeUrl, out string videoPath, null))
            {
                path = failurePath;
                return false;
            }

            try
            {
                ConverterService.ConvertVideoToMp3(videoPath, path, failurePath);

                while (inConvertingProgress.ContainsKey(youtubeUrl))
                {
                    inConvertingProgress.TryRemove(youtubeUrl, out _);
                }

                return true;
            }
            catch
            {
                path = failurePath;
                return false;
            }
        }

        public static bool GetPlayablePath(string youtubeUrl, out string path)
        {
            path = downloadedAudioPath(youtubeUrl);

            if (File.Exists(path))
            {
                return true;
            }

            path = downloadedVideoPath(youtubeUrl);

            return File.Exists(path);
        }

        public static string GetImageFilePath(DiscogsImage image)
        {
            if (image == null)
            {
                return null;
            }

            ensureExistingDirectory(ImageFolder);

            string path = getImageFilePath(image.uri);

            if (!File.Exists(path))
            {
                DiscogsService.DownloadImage(image, path);
            }

            return path;
        }

        public static void ExportRelease(DiscogsRelease release, string folder, Dictionary<string, string> exportFields)
        {
            if (release.videos == null)
            {
                return;
            }

            foreach (DiscogsVideo releaseVideo in release.videos)
            {
                if (!GetAudioFilePath(releaseVideo.uri, out string src))
                {
                    continue;
                }

                string releaseVideoTitle = releaseVideo.title;

                string fieldExport = "";

                if (exportFields.Any())
                {
                    fieldExport = " (";

                    foreach (string fieldName in exportFields.Keys)
                    {
                        if (fieldExport != " (")
                            fieldExport += ", ";

                        fieldExport += $"{fieldName}-{exportFields[fieldName]}";
                    }

                    fieldExport += ")";

                    releaseVideoTitle += fieldExport;
                }

                string filename = getEscaped(releaseVideoTitle);

                string releaseName = $"{string.Join(", ", release.artists?.Select(a => a.name).ToArray() ?? new string[0])} - {release.title}{fieldExport}";

                foreach (char invalidPathChar in Path.GetInvalidPathChars())
                {
                    releaseName = releaseName.Replace(invalidPathChar, ' ');
                }

                string destFolder = Path.Combine(folder, getEscaped(releaseName)).Trim();

                if (!Directory.Exists(destFolder))
                {
                    Directory.CreateDirectory(destFolder);

                }
                string dest = Path.Combine(destFolder , $"{filename}{AudioExtension}");

                if (!File.Exists(src) || File.Exists(dest))
                {
                    continue;
                }

                try
                {
                    File.Copy(src, dest);
                    TagLib.File file = TagLib.File.Create(dest);
                    DiscogsTrack track = getTrack(releaseVideo, release);
                    file.Tag.Title = track?.title;
                    if (!string.IsNullOrWhiteSpace(file.Tag.Title)) file.Tag.Title += fieldExport;
                    file.Tag.Performers = track?.artists?.Select(a => a.name).ToArray()
                                          ?? release.artists?.Select(a => a.name).ToArray()
                                          ?? new string[0];
                    file.Tag.Album = release.title;
                    file.Tag.AlbumArtists = release.artists?.Select(a => a.name).ToArray() ?? new string[0];
                    file.Tag.Genres = release.genres;
                    try
                    {
                        IPicture cover = new Picture(GetImageFilePath(release.images?[0]));
                        file.Tag.Pictures = new[] { cover };
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($@"tagging {release.title}{e}");
                    }

                    file.Save();
                }
                catch (Exception e)
                {
                    Console.WriteLine($@"{src}  -->   {dest}  {e}");
                }
            }
        }

        #region private methods
        
        private static DiscogsTrack getTrack(DiscogsVideo video, DiscogsRelease release)
        {
            DiscogsTrack[] tracksByTitle = release.tracklist.Where(t => video.title.ToLower().Contains(t.title.ToLower())).ToArray();

            if (tracksByTitle.Length > 1)
            {
                DiscogsTrack[] tracksByArtist = tracksByTitle.Where(t =>
                {
                    DiscogsReleaseArtist[] discogsReleaseArtists = t.artists ?? release.artists;
                    return discogsReleaseArtists.Any(a => video.title.ToLower().Contains(a.name)) == true;
                }).ToArray();

                if (tracksByArtist.Length > 1)
                {
                    return null;
                }

                if (tracksByArtist.Length == 1)
                {
                    return tracksByArtist[0];
                }
            }

            if (tracksByTitle.Length == 1)
            {
                return tracksByTitle[0];
            }
            return null;
        }
        
        private static string downloadedVideoPath(string url)
        {
            getVideoFilePath(url, out string successPath, out string failurePath);

            if (File.Exists(successPath))
            {
                return successPath;
            }

            if (File.Exists(failurePath))
            {
                return failurePath;
            }

            return null;
        }

        private static string downloadedAudioPath(string url)
        {
            getAudioFilePath(url, out string successPath, out string failurePath);

            if (File.Exists(successPath))
            {
                return successPath;
            }

            if (File.Exists(failurePath))
            {
                return failurePath;
            }

            return null;
        }

        private static void getVideoFilePath(string youtubeUrl, out string successPath, out string failurePath)
        {
            string fileKey = getEscaped(youtubeUrl);
            successPath = Path.Combine(VideoFolder, $"{fileKey}{SuccessSuffix}{VideoExtension}");
            failurePath = Path.Combine(VideoFolder, $"{fileKey}{FailureSuffix}{VideoExtension}");
        }

        private static void getAudioFilePath(string youtubeUrl, out string successPath, out string failurePath)
        {
            string fileKey = getEscaped(youtubeUrl);
            successPath = Path.Combine(AudioFolder, $"{fileKey}{SuccessSuffix}{AudioExtension}");
            failurePath = Path.Combine(AudioFolder, $"{fileKey}{FailureSuffix}{AudioExtension}");
        }

        private static string getImageFilePath(string imageUrl)
        {
            return Path.Combine(ImageFolder, getEscaped(imageUrl) + ImageExtension);
        }

        private static string getEscaped(string youtubeUrl)
        {
            return Path.GetInvalidFileNameChars().Aggregate(youtubeUrl, (current, invalidFileNameChar) => current.Replace(invalidFileNameChar, '_'));
        }

        private static void ensureExistingDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private static readonly ConcurrentDictionary<string, string> inDownloadingProgress = new ConcurrentDictionary<string, string>();

        private static readonly ConcurrentDictionary<string, string> inConvertingProgress = new ConcurrentDictionary<string, string>();

        #endregion
    }
}