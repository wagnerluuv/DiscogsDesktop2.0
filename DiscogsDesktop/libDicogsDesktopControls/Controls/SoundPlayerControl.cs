using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AxWMPLib;
using JetBrains.Annotations;
using libDicogsDesktopControls.Extensions;
using WMPLib;

namespace libDicogsDesktopControls.Controls
{
    public sealed partial class SoundPlayerControl : UserControl
    {
        private readonly List<Tuple<string, string>> playList = new List<Tuple<string, string>>();

        private int playingIndex;

        private bool stoppPressed;

        public event Action TrackFinished;

        public event Action NextTrackRequested;

        public SoundPlayerControl()
        {
            this.InitializeComponent();
            this.mediaplayer.settings.volume = this.trackBarVolume.Value = 100;
            this.labelTitle.Text = this.labelDuration.Text = null;
        }

        public void Play(string url, string title)
        {
            this.InvokeIfRequired(() =>
            {
                this.mediaplayer.URL = url;
                this.labelTitle.Text = title;
                this.playList.Add(new Tuple<string, string>(url, title));
                this.playingIndex = this.playList.Count - 1;
            });
        }

        private int getTrackbarPosition()
        {
            int position = Convert.ToInt32(this.mediaplayer.Ctlcontrols.currentPosition / this.mediaplayer.currentMedia?.duration * this.trackBarPosition.Maximum);
            return position > this.trackBarPosition.Maximum ? this.trackBarPosition.Maximum : position;
        }

        private void setTrackPosition()
        {
            if (File.Exists(this.mediaplayer.URL))
            {
                this.mediaplayer.Ctlcontrols.currentPosition = Convert.ToDouble(this.trackBarPosition.Value) / this.trackBarPosition.Maximum * this.mediaplayer.currentMedia.duration;
            }
        }

        private void buttonPlayClick(object sender, EventArgs e)
        {
            this.mediaplayer.Ctlcontrols.play();
        }

        private void buttonPauseClick(object sender, EventArgs e)
        {
            this.mediaplayer.Ctlcontrols.pause();
        }

        private void buttonStopClick(object sender, EventArgs e)
        {
            this.stoppPressed = true;
            this.mediaplayer.Ctlcontrols.stop();
            this.trackBarPosition.Value = 0;
        }

        private void timerUpdatePositionTick(object sender, EventArgs e)
        {
            try
            {
                if (this.mediaplayer.playState == WMPPlayState.wmppsPlaying)
                {
                    this.trackBarPosition.InvokeIfRequired(() => { this.trackBarPosition.Value = this.getTrackbarPosition(); });
                    TimeSpan position = TimeSpan.FromSeconds(this.mediaplayer.Ctlcontrols.currentPosition);
                    this.labelTitle.InvokeIfRequired(() =>
                    {
                        this.labelDuration.Text =
                            $"{position.Minutes.ToString().PadLeft(2, '0')}:{position.Seconds.ToString().PadLeft(2, '0')}/" +
                            $"{this.mediaplayer.currentMedia.durationString}";
                    });
                }
            }
            catch { }
        }

        private void trackBarPositionMouseDown(object sender, MouseEventArgs e)
        {
            this.timerUpdatePosition.Enabled = false;
        }

        private void trackBarPositionMouseUp(object sender, MouseEventArgs e)
        {
            this.setTrackPosition();
            this.timerUpdatePosition.Enabled = true;
        }

        private void buttonPreviousClick(object sender, EventArgs e)
        {
            if (this.playingIndex == 0)
            {
                return;
            }

            this.playingIndex--;
            this.mediaplayer.URL = this.playList[this.playingIndex].Item1;
            this.labelTitle.Text = this.playList[this.playingIndex].Item2;
        }

        private void buttonNextClick(object sender, EventArgs e)
        {
            if (this.playingIndex == this.playList.Count - 1)
            {
                this.NextTrackRequested?.Invoke();
                return;
            }

            this.playingIndex++;
            this.mediaplayer.URL = this.playList[this.playingIndex].Item1;
            this.labelTitle.Text = this.playList[this.playingIndex].Item2;
        }

        private void mediaplayerPlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (this.stoppPressed)
            {
                this.stoppPressed = false;
                return;
            }

            if (this.mediaplayer.playState == WMPPlayState.wmppsStopped)
            {
                this.TrackFinished?.Invoke();
            }
        }

        private void trackBarVolumeScroll(object sender, EventArgs e)
        {
            try
            {
                this.mediaplayer.settings.volume = this.trackBarVolume.Value;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}