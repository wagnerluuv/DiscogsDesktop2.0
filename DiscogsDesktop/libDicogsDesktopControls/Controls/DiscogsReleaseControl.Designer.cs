namespace libDicogsDesktopControls.Controls
{
    sealed partial class DiscogsReleaseControl
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.flowLayoutPanelVideos = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabelGoToUrl = new System.Windows.Forms.LinkLabel();
            this.labelLabel = new System.Windows.Forms.Label();
            this.linkLabelLabel = new System.Windows.Forms.LinkLabel();
            this.labelArtist = new System.Windows.Forms.Label();
            this.flowLayoutPanelArtists = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonExportReleases = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanelVideos
            // 
            this.flowLayoutPanelVideos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelVideos.AutoScroll = true;
            this.flowLayoutPanelVideos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelVideos.Location = new System.Drawing.Point(179, 48);
            this.flowLayoutPanelVideos.Name = "flowLayoutPanelVideos";
            this.flowLayoutPanelVideos.Size = new System.Drawing.Size(590, 338);
            this.flowLayoutPanelVideos.TabIndex = 1;
            // 
            // linkLabelGoToUrl
            // 
            this.linkLabelGoToUrl.AutoSize = true;
            this.linkLabelGoToUrl.Location = new System.Drawing.Point(3, 221);
            this.linkLabelGoToUrl.Name = "linkLabelGoToUrl";
            this.linkLabelGoToUrl.Size = new System.Drawing.Size(88, 13);
            this.linkLabelGoToUrl.TabIndex = 3;
            this.linkLabelGoToUrl.TabStop = true;
            this.linkLabelGoToUrl.Text = "view in browser";
            this.linkLabelGoToUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGoToUrlLinkClicked);
            // 
            // labelLabel
            // 
            this.labelLabel.AutoSize = true;
            this.labelLabel.Location = new System.Drawing.Point(6, 247);
            this.labelLabel.Name = "labelLabel";
            this.labelLabel.Size = new System.Drawing.Size(32, 13);
            this.labelLabel.TabIndex = 4;
            this.labelLabel.Text = "label";
            // 
            // linkLabelLabel
            // 
            this.linkLabelLabel.AutoSize = true;
            this.linkLabelLabel.Location = new System.Drawing.Point(3, 260);
            this.linkLabelLabel.Name = "linkLabelLabel";
            this.linkLabelLabel.Size = new System.Drawing.Size(60, 13);
            this.linkLabelLabel.TabIndex = 5;
            this.linkLabelLabel.TabStop = true;
            this.linkLabelLabel.Text = "labelname";
            this.linkLabelLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLabelLinkClicked);
            // 
            // labelArtist
            // 
            this.labelArtist.AutoSize = true;
            this.labelArtist.Location = new System.Drawing.Point(8, 283);
            this.labelArtist.Name = "labelArtist";
            this.labelArtist.Size = new System.Drawing.Size(38, 13);
            this.labelArtist.TabIndex = 6;
            this.labelArtist.Text = "artists";
            // 
            // flowLayoutPanelArtists
            // 
            this.flowLayoutPanelArtists.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanelArtists.Location = new System.Drawing.Point(6, 299);
            this.flowLayoutPanelArtists.Name = "flowLayoutPanelArtists";
            this.flowLayoutPanelArtists.Size = new System.Drawing.Size(167, 90);
            this.flowLayoutPanelArtists.TabIndex = 7;
            // 
            // buttonExportReleases
            // 
            this.buttonExportReleases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExportReleases.Location = new System.Drawing.Point(642, 23);
            this.buttonExportReleases.Name = "buttonExportReleases";
            this.buttonExportReleases.Size = new System.Drawing.Size(127, 23);
            this.buttonExportReleases.TabIndex = 16;
            this.buttonExportReleases.TabStop = false;
            this.buttonExportReleases.Text = "export release";
            this.buttonExportReleases.UseVisualStyleBackColor = true;
            this.buttonExportReleases.Click += new System.EventHandler(this.buttonExportReleasesClick);
            // 
            // DiscogsReleaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.buttonExportReleases);
            this.Controls.Add(this.flowLayoutPanelArtists);
            this.Controls.Add(this.labelArtist);
            this.Controls.Add(this.linkLabelLabel);
            this.Controls.Add(this.labelLabel);
            this.Controls.Add(this.linkLabelGoToUrl);
            this.Controls.Add(this.flowLayoutPanelVideos);
            this.Name = "DiscogsReleaseControl";
            this.Size = new System.Drawing.Size(772, 389);
            this.Type = "release";
            this.Controls.SetChildIndex(this.flowLayoutPanelVideos, 0);
            this.Controls.SetChildIndex(this.linkLabelGoToUrl, 0);
            this.Controls.SetChildIndex(this.labelLabel, 0);
            this.Controls.SetChildIndex(this.linkLabelLabel, 0);
            this.Controls.SetChildIndex(this.labelArtist, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanelArtists, 0);
            this.Controls.SetChildIndex(this.buttonExportReleases, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelVideos;
        private System.Windows.Forms.LinkLabel linkLabelGoToUrl;
        private System.Windows.Forms.Label labelLabel;
        private System.Windows.Forms.LinkLabel linkLabelLabel;
        private System.Windows.Forms.Label labelArtist;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelArtists;
        private System.Windows.Forms.Button buttonExportReleases;
    }
}
