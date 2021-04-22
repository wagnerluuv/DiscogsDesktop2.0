using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using libDiscogsDesktop.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace libDiscogsDesktop.Services
{
    public static class YoutubeService
    {
        public static bool GetAudio(string url, string successPath, string failurePath, TaskProgressReporter reporter)
        {
            if (!DownloadVideoViaYoutubeExplode(url, successPath, failurePath, reporter))
            {
                return false;
            }

            return true;
        }

        public static bool DownloadVideoViaYoutubeExplode(string url, string successPath, string failurePath, TaskProgressReporter reporter)
        {
            try
            {
                reporter?.ReportInDeterminate("getting links");

                VideoId videoId = VideoId.Parse(url);
                YoutubeClient client = new YoutubeClient();

                StreamManifest streams = client.Videos.Streams.GetManifestAsync(videoId).Result;

                IEnumerable<AudioOnlyStreamInfo> audioStreams = streams.GetAudioOnlyStreams().Where(info => info.Container == Container.Mp4).ToArray();

                IStreamInfo streamInfo;

                streamInfo = streams.GetAudioOnlyStreams().FirstOrDefault(info => info.Bitrate.BitsPerSecond == audioStreams.Max(onlyStreamInfo => onlyStreamInfo.Bitrate.BitsPerSecond));

                if (streamInfo == null)
                {
                    streamInfo = streams.GetMuxedStreams().GetWithHighestVideoQuality();
                }

                if (streamInfo == null)
                {
                    throw new Exception($"no video streams available for {url}");
                }

                Progress<double> progress = reporter == null
                    ? null
                    : new Progress<double>(d => reporter.ReportDeterminate((int) (d * 100), "downloading"));

                client.Videos.Streams.DownloadAsync(streamInfo, successPath, progress).AsTask().Wait();

                return true;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
                File.Create(failurePath).Close();
                return false;
            }
        }
    }
}