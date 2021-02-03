using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlSelector;
using libDiscogsDesktop.Models;
using libDiscogsDesktop.Services;

namespace libDicogsDesktopControls.ControlModels
{
    public sealed class VideoControlModel : DependencyObject
    {
        public VideoModel VideoModel { get; }

        public string VideoFilePath { get; private set; }

        public bool DownloadSuccessfull { get; private set; }

        public event Action LoadingFinished;

        public VideoControlModel(VideoModel videoModel)
        {
            this.VideoModel = videoModel;
        }

        public void StartLoading(Action<double> progressHandler)
        {
            Task.Run(() =>
            {
                this.DownloadSuccessfull = MediaService.GetVideoFilePath(this.VideoModel.Url, out string path, progressHandler);
                this.VideoFilePath = path;

                Task.Run(() => { MediaService.GetAudioFilePath(this.VideoModel.Url, out _); });

                this.LoadingFinished?.Invoke();
            });
        }

        public void PlayAudio()
        {
            GlobalControls.SoundPlayerControl.Play(this.VideoFilePath, this.VideoModel.Title);
        }

        public void PlayVideo()
        {
            Process.Start(this.VideoFilePath);
        }

        public void OpenVideoUrl()
        {
            Process.Start(this.VideoModel.Url);
        }
    }
}