using System;
using System.Linq;
using System.Windows.Forms;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlBase;
using libDicogsDesktopControls.ControlModels;
using libDicogsDesktopControls.ControlSelector;
using libDicogsDesktopControls.Extensions;
using libDiscogsDesktop.Models;

namespace libDicogsDesktopControls.Controls
{
    public sealed partial class DiscogsReleaseControl : TypeTitleImageControl
    {
        private readonly DiscogsReleaseControlModel viewmodel;

        public DiscogsReleaseControl(DiscogsRelease release)
        {
            this.InitializeComponent();

            this.viewmodel = new DiscogsReleaseControlModel(release);

            this.linkLabelLabel.Text = this.viewmodel.LabelName;

            this.DataBindings.Add(nameof(this.Title), this.viewmodel, nameof(this.viewmodel.Title), true, DataSourceUpdateMode.OnPropertyChanged);

            this.viewmodel.ImageLoaded += () => { this.InvokeIfRequired(() => { this.Image = this.viewmodel.Image; }); };

            this.viewmodel.LabelLoaded += this.viewmodelOnLabelLoaded;

            this.viewmodel.ArtistLoaded += this.viewmodelOnArtistLoaded;

            this.viewmodel.StartImageLoading();

            if (this.viewmodel.Videos.Length == 0)
            {
                this.flowLayoutPanelVideos.Controls.Add(new NoVideosFoundControl());
            }

            foreach (VideoModel videoModel in this.viewmodel.Videos)
            {
                this.flowLayoutPanelVideos.InvokeIfRequired(() =>
                {
                    VideoControl control = new VideoControl(videoModel);
                    this.flowLayoutPanelVideos.Controls.Add(control);
                });
            }

            foreach (DiscogsReleaseArtist artist in this.viewmodel.Artists ?? new DiscogsReleaseArtist[0])
            {
                LinkLabel artistLink = new LinkLabel { Text = artist.name };
                int height = artistLink.Height;
                artistLink.AutoSize = false;
                artistLink.Height = height;
                artistLink.Width = this.flowLayoutPanelArtists.ClientSize.Width;
                artistLink.LinkClicked += (sender, args) => { this.viewmodel.StartGetArtist(artist); };
                this.flowLayoutPanelArtists.Controls.Add(artistLink);
            }
        }

        private void viewmodelOnArtistLoaded(DiscogsArtist obj)
        {
            GlobalControls.DiscogsEntityControlPanel.InvokeIfRequired(() =>
            {
                GlobalControls.DiscogsEntityControlPanel.Controls.Cast<Control>().FirstOrDefault()?.Dispose();
                GlobalControls.DiscogsEntityControlPanel.Controls.Clear();
                DiscogsArtistControl control = new DiscogsArtistControl(obj);
                GlobalControls.DiscogsEntityControlPanel.Controls.Add(control);
                control.Dock = DockStyle.Fill;
            });
        }

        private void viewmodelOnLabelLoaded(DiscogsLabel obj)
        {
            GlobalControls.DiscogsEntityControlPanel.InvokeIfRequired(() =>
            {
                GlobalControls.DiscogsEntityControlPanel.Controls.Cast<Control>().FirstOrDefault()?.Dispose();
                GlobalControls.DiscogsEntityControlPanel.Controls.Clear();
                DiscogsLabelControl control = new DiscogsLabelControl(obj);
                GlobalControls.DiscogsEntityControlPanel.Controls.Add(control);
                control.Dock = DockStyle.Fill;
            });
        }

        private void linkLabelGoToUrlLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.viewmodel.OpenInBrowser();
        }

        private void linkLabelLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.viewmodel.StartGetLabel();
        }

        private void buttonExportReleasesClick(object sender, EventArgs e)
        {
            this.viewmodel.ExportRelease();
        }
    }
}