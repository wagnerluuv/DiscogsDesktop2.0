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
    public sealed class DiscogsLabelControlModel : TitleAndImageControlModel
    {
        private readonly DiscogsLabel label;

        private readonly ObservableCollection<DiscogsLabelRelease> releases = new ObservableCollection<DiscogsLabelRelease>();

        public string SearchPattern
        {
            get { return (string)this.GetValue(SearchPatternProperty); }
            set { this.SetValue(SearchPatternProperty, value); }
        }

        public static readonly DependencyProperty SearchPatternProperty = DependencyProperty.Register(
            nameof(SearchPattern), typeof(string), typeof(DiscogsLabelControlModel), new PropertyMetadata());

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

        public DiscogsLabelControlModel(DiscogsLabel label)
        {
            this.label = label;
            this.Title = label.name;
            this.releases.CollectionChanged += this.releasesOnCollectionChanged;

            this.ReleasesTable.Columns.AddRange(new[]
                {
                    new DataColumn("Title"),
                    new DataColumn("Artist"),
                    new DataColumn("Year"),
                    new DataColumn("Id"),
                });

            DiscogsService.GetLabelReleases(label.id, this.releases);
        }

        public override void StartImageLoading()
        {
            Task.Run(() =>
            {
                if (this.label.images != null && this.label.images.Length > 0)
                {
                    this.Image = Image.FromFile(MediaService.GetImageFilePath(this.label.images[0]));
                }
            });
        }

        public void SelectRelease(DataRow row)
        {
            Task.Run(() => { this.SelectedRelease = DiscogsService.GetRelease(int.Parse(row["Id"].ToString())); });
        }

        public void Search()
        {
            try
            {
                this.ReleasesTable.DefaultView.RowFilter = $"Title LIKE '%{this.SearchPattern}%'";
            }
            catch
            {
                //ignore
            }
        }

        public void ViewInBrowser()
        {
            Process.Start(this.label.uri);
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
            foreach (DiscogsLabelRelease release in e.NewItems ?? new DiscogsLabelRelease[0])
            {
                this.ReleasesTable.Rows.Add(release.title, release.artist, release.year, release.id);
            }
        }
    }
}