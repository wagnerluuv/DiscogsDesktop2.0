using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlModelBase;
using libDicogsDesktopControls.Helper;
using libDiscogsDesktop.Models;
using libDiscogsDesktop.Services;

namespace libDicogsDesktopControls.ControlModels
{
    public sealed class DiscogsReleaseControlModel : TitleAndImageControlModel
    {
        private readonly DiscogsRelease release;

        public readonly VideoModel[] Videos;

        public readonly DiscogsReleaseArtist[] Artists;

        public event Action<DiscogsLabel> LabelLoaded;

        public event Action<DiscogsArtist> ArtistLoaded;

        public readonly string LabelName;

        public DiscogsReleaseControlModel(DiscogsRelease release)
        {
            this.release = release;
            this.Title = release.title;
            this.Artists = release.artists;
            this.LabelName = release.labels?[0].name;
            this.Videos = (release.videos ?? new DiscogsVideo[0]).Select(v => new VideoModel(v.uri, v.title)).ToArray();
        }

        public override void StartImageLoading()
        {
            Task.Run(() =>
            {
                if (this.release.images != null && this.release.images.Length > 0)
                {
                    this.Image = Image.FromFile(MediaService.GetImageFilePath(this.release.images[0]));
                }
            });
        }

        public void OpenInBrowser()
        {
            Process.Start(this.release.uri);
        }

        public void StartGetArtist(DiscogsReleaseArtist artist)
        {
            Task.Run(() => { this.ArtistLoaded?.Invoke(DiscogsService.GetArtist(artist.id)); });
        }

        public void StartGetLabel()
        {
            Task.Run(() => { this.LabelLoaded?.Invoke(DiscogsService.GetLabel(this.release.labels[0].id)); });
        }

        public void ExportRelease()
        {
            ExportAndDownloadHelper.ReleasesHelp(new[] { this.release.id }, Help.Export);
        }
    }
}