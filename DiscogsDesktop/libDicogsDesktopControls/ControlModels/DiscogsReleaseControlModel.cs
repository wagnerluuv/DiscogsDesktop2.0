using System;
using System.Data;
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
        private const string LikesColumnName = " <3 ";

        private readonly DiscogsRelease release;

        public readonly VideoModel[] Videos;

        public readonly DiscogsReleaseArtist[] Artists;

        public event Action<DiscogsLabel> LabelLoaded;

        public event Action<DiscogsArtist> ArtistLoaded;

        public readonly string LabelName;

        public DataTable TracksTable;

        public DiscogsReleaseControlModel(DiscogsRelease release)
        {
            this.release = release;
            this.Title = release.title;
            this.Artists = release.artists;
            this.LabelName = release.labels?[0].name;
            this.Videos = (release.videos ?? new DiscogsVideo[0]).Select(v => new VideoModel(v.uri, v.title)).ToArray();
            this.generateTracksTable();
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

        private void generateTracksTable()
        {
            this.TracksTable = new DataTable();

            this.TracksTable.Columns.AddRange(new[]
            {
                this.newLikeColumn(),
                this.newReadOnlyColumn("Track"),
                this.newReadOnlyColumn("Title"),
                this.newReadOnlyColumn("Artist")
            });

            foreach (DiscogsTrack discogsTrack in this.release.tracklist)
            {
                string artist = discogsTrack.artists == null
                ? string.Join(", ", this.release.artists.Select(releaseArtist => releaseArtist.name))
                : string.Join(", ", discogsTrack.artists?.Select(trackArtist => trackArtist.name));

                this.TracksTable.Rows.Add(
                    DiscogsService.LikesTrack(this.release, discogsTrack.position),
                    discogsTrack.position,
                    discogsTrack.title,
                    artist
                );
            }
        }

        private DataColumn newReadOnlyColumn(string name)
        {
            return new DataColumn(name)
            {
                ReadOnly = true
            };
        }
    
        private DataColumn newLikeColumn()
        {
            DataColumn likeColumn = new DataColumn(LikesColumnName, typeof(bool));

            return likeColumn;
        }

        public void LikeChanged(int rowIndex)
        {
            DataRow tracksTableRow = this.TracksTable.Rows[rowIndex];
            DiscogsService.LikeTrack(this.release, tracksTableRow["Track"].ToString(), Convert.ToBoolean(tracksTableRow[LikesColumnName]));
        }
    }
}