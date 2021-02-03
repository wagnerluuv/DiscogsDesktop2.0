using System;
using JetBrains.Annotations;

namespace libDicogsDesktopControls.Controls
{
    sealed partial class SoundPlayerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundPlayerControl));
            this.trackBarPosition = new System.Windows.Forms.TrackBar();
            this.timerUpdatePosition = new System.Windows.Forms.Timer(this.components);
            this.mediaplayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediaplayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarPosition.Location = new System.Drawing.Point(96, 47);
            this.trackBarPosition.Maximum = 1000000;
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.Size = new System.Drawing.Size(234, 45);
            this.trackBarPosition.TabIndex = 3;
            this.trackBarPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarPositionMouseDown);
            this.trackBarPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarPositionMouseUp);
            // 
            // timerUpdatePosition
            // 
            this.timerUpdatePosition.Enabled = true;
            this.timerUpdatePosition.Tick += new System.EventHandler(this.timerUpdatePositionTick);
            // 
            // mediaplayer
            // 
            this.mediaplayer.Enabled = true;
            this.mediaplayer.Location = new System.Drawing.Point(360, 3);
            this.mediaplayer.Name = "mediaplayer";
            this.mediaplayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaplayer.OcxState")));
            this.mediaplayer.Size = new System.Drawing.Size(75, 23);
            this.mediaplayer.TabIndex = 4;
            this.mediaplayer.Visible = false;
            this.mediaplayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.mediaplayerPlayStateChange);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.AutoEllipsis = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(3, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(446, 25);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "title";
            // 
            // labelDuration
            // 
            this.labelDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDuration.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDuration.Location = new System.Drawing.Point(455, 0);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(121, 25);
            this.labelDuration.TabIndex = 5;
            this.labelDuration.Text = "23:00/23:00";
            this.labelDuration.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVolume.Location = new System.Drawing.Point(471, 47);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(72, 45);
            this.trackBarVolume.TabIndex = 8;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolumeScroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::libDicogsDesktopControls.Properties.Resources.loudspeaker4;
            this.pictureBox1.Location = new System.Drawing.Point(540, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Image = global::libDicogsDesktopControls.Properties.Resources.media_end;
            this.buttonNext.Location = new System.Drawing.Point(426, 37);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(39, 39);
            this.buttonNext.TabIndex = 7;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNextClick);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrevious.Image = global::libDicogsDesktopControls.Properties.Resources.media_beginning;
            this.buttonPrevious.Location = new System.Drawing.Point(336, 37);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(39, 39);
            this.buttonPrevious.TabIndex = 6;
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPreviousClick);
            // 
            // buttonStop
            // 
            this.buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.Image = global::libDicogsDesktopControls.Properties.Resources.media_stop;
            this.buttonStop.Location = new System.Drawing.Point(381, 37);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(39, 39);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStopClick);
            // 
            // buttonPause
            // 
            this.buttonPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPause.Image = global::libDicogsDesktopControls.Properties.Resources.media_pause;
            this.buttonPause.Location = new System.Drawing.Point(48, 37);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(39, 39);
            this.buttonPause.TabIndex = 1;
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPauseClick);
            // 
            // buttonPlay
            // 
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.Image = global::libDicogsDesktopControls.Properties.Resources.media_play;
            this.buttonPlay.Location = new System.Drawing.Point(3, 37);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(39, 39);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlayClick);
            // 
            // SoundPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.mediaplayer);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.trackBarPosition);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonPlay);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SoundPlayer";
            this.Size = new System.Drawing.Size(579, 79);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediaplayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TrackBar trackBarPosition;
        private System.Windows.Forms.Timer timerUpdatePosition;
        private AxWMPLib.AxWindowsMediaPlayer mediaplayer;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
