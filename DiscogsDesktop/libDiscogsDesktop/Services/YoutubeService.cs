using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using libDiscogsDesktop.Tasks;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace libDiscogsDesktop.Services
{
    public static class YoutubeService
    {
        public static bool DownloadVideoViaYoutubeExplode(string url, string successPath, string failurePath, TaskProgressReporter reporter)
        {
            try
            {
                reporter?.ReportInDeterminate("getting links");

                string id = YoutubeClient.ParseVideoId(url);
                YoutubeClient client = new YoutubeClient();
                MediaStreamInfoSet streamInfoSet = client.GetVideoMediaStreamInfosAsync(id).Result;

                MuxedStreamInfo streamInfo = streamInfoSet.Muxed.First(m => m.Container.GetFileExtension().ToLower() == "mp4");
                //string ext = streamInfo.Container.GetFileExtension();
                client.DownloadMediaStreamAsync(streamInfo, successPath, reporter == null 
                    ? null 
                    : new Progress<double>(d => reporter.ReportDeterminate((int)(d * 100), "downloading"))).Wait();
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