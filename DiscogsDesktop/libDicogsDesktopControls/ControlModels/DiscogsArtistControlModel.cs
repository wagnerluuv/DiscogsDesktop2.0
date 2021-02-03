using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlModelBase;
using libDicogsDesktopControls.Helper;
using libDiscogsDesktop.Services;

namespace libDicogsDesktopControls.ControlModels
{
    public class DiscogsArtistControlModel : TitleAndImageControlModel
    {
        private readonly DiscogsArtist artist;

        private readonly ObservableCollection<DiscogsArtistRelease> releases = new ObservableCollection<DiscogsArtistRelease>();

        public string ArtistSearchPattern
        {
            get => (string)this.GetValue(ArtistSearchPatternProperty);
            set => this.SetValue(ArtistSearchPatternProperty, value);
        }

        public static readonly DependencyProperty ArtistSearchPatternProperty = DependencyProperty.Register(
            nameof(ArtistSearchPattern), typeof(string), typeof(DiscogsLabelControlModel), new PropertyMetadata());

        public readonly DataTable ReleasesTable = new DataTable();

        public event Action SelectedReleaseChanged;

        private DiscogsRelease selectedRelease;

        public DiscogsRelease SelectedRelease
        {
            get => this.selectedRelease;
            set
            {
                this.selectedRelease = value;
                this.SelectedReleaseChanged?.Invoke();
            }
        }

        public DiscogsArtistControlModel(DiscogsArtist artist)
        {
            this.artist = artist;
            this.Title = artist.name;
            this.releases.CollectionChanged += this.releasesOnCollectionChanged;

            this.ReleasesTable.Columns.AddRange(new[]
                {
                    new DataColumn("Title"),
                    new DataColumn("Artist"),
                    new DataColumn("Year"),
                    new DataColumn("Id"),
                });

            DiscogsService.GetArtistReleases(artist.id, this.releases);
        }

        public override void StartImageLoading()
        {
            Task.Run(() => { this.Image = Image.FromFile(MediaService.GetImageFilePath(this.artist.images[0])); });
        }

        public void SelectRelease(DataRow row)
        {
            Task.Run(() => { this.SelectedRelease = DiscogsService.GetRelease(int.Parse(row["Id"].ToString())); });
        }

        public void Search()
        {
            try
            {
                this.ReleasesTable.DefaultView.RowFilter = $"Title LIKE '%{this.ArtistSearchPattern}%'";
            }
            catch
            {
                //ignore
            }
        }

        public void ViewInBrowser()
        {
            Process.Start(this.artist.uri);
        }

        public void DownloadReleases()
        {
            ExportAndDownloadHelper.ReleasesHelp(this.ReleasesTable.Rows, Help.Download);
        }

        public void ExportReleases()
        {
            ExportAndDownloadHelper.ReleasesHelp(this.ReleasesTable.Rows, Help.Export);
        }

        private void releasesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (DiscogsArtistRelease release in e.NewItems ?? new DiscogsLabelRelease[0])
            {
                this.ReleasesTable.Rows.Add(release.title, release.artist, release.year, release.id);
            }
        }
    }
}