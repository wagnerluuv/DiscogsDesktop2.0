using System;
using System.Windows.Forms;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlBase;
using libDicogsDesktopControls.ControlModels;
using libDicogsDesktopControls.Extensions;
using libDiscogsDesktop.Models;
using libDiscogsDesktop.Tasks;

namespace libDicogsDesktopControls.Controls
{
    public sealed partial class VideoControl : LeftToRightDockingControl
    {
        private readonly VideoControlModel controlModel;

        public VideoControl(VideoModel videoModel)
        {
            this.InitializeComponent();
            this.labelTitle.Text = videoModel.Title;
            this.controlModel = new VideoControlModel(videoModel);
            this.controlModel.LoadingFinished += this.controlModelOnLoadingFinished;
            this.controlModel.StartLoading(this.setProgress);
        }

        private void controlModelOnLoadingFinished()
        {
            this.InvokeIfRequired(() =>
            {
                this.buttonPlayAudio.Enabled = this.buttonExport.Enabled = this.controlModel.DownloadSuccessfull;
                this.progressBarLoading.Visible = false;
            });
        }

        private void buttonPlayAudioClick(object sender, EventArgs e)
        {
            this.controlModel.PlayAudio();
        }

        private void buttonExportClick(object sender, EventArgs e)
        {
            this.controlModel.Export();
        }
   
        private void buttonOpenUrlClick(object sender, EventArgs e)
        {
            this.controlModel.OpenVideoUrl();
        }

        private void setProgress(TaskProgress progress)
        {
            this.progressBarLoading.InvokeIfRequired(() =>
            {
                this.progressBarLoading.Style = progress.ProgressBarStyle();
                this.progressBarLoading.Value = progress.Percentage;
            });
        }
 }
}