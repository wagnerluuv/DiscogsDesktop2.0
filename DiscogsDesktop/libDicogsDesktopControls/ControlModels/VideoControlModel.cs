using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlSelector;
using libDiscogsDesktop.Models;
using libDiscogsDesktop.Services;
using libDiscogsDesktop.Tasks;

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

        public void StartLoading(TaskManager.TaskProgressHandler handler)
        {
            string id = $"load{this.VideoModel.Url}";

            TaskManager.Run(this.load, id, handler, this.loadingFinished);
        }

        public void PlayAudio()
        {
            Task.Run(() => { GlobalControls.SoundPlayerControl.Play(this.VideoFilePath, this.VideoModel.Title); });
        }

        public void Export()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() != DialogResult.OK || !MediaService.GetAudioFilePath(this.VideoModel.Url, out string path))
                {
                    return;
                }
                
                string name = Path.GetInvalidFileNameChars()
                    .Aggregate(this.VideoModel.Title, (current, invalidFileNameChar) => current.Replace(invalidFileNameChar, ' '));

                File.Copy(path, Path.Combine(dialog.SelectedPath, name + ".mp3"), true);
            }
        }

        public void OpenVideoUrl()
        {
            Process.Start(this.VideoModel.Url);
        }

        private void load(TaskProgressReporter reporter)
        {
            MediaService.GetVideoFilePath(this.VideoModel.Url, out string path, reporter);
            this.VideoFilePath = path;
        }

        private void loadingFinished()
        {
            this.DownloadSuccessfull = MediaService.GetVideoFilePath(this.VideoModel.Url, out _, null);
            this.LoadingFinished?.Invoke();
        }
    }
}