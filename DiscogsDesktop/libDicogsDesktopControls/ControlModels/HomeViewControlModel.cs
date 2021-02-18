using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DiscogsClient.Data.Query;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using libDicogsDesktopControls.Helper;
using libDiscogsDesktop.Helper;
using libDiscogsDesktop.Services;

namespace libDicogsDesktopControls.ControlModels
{
    public sealed class HomeViewControlModel : DependencyObject
    {
        #region private fields

        private DiscogsEntity selectedEntity;

        private string collectionSearchPattern => string.Join(" OR ", this.CollectionTable.Columns.Cast<DataColumn>()
            .Where(c=>c.ColumnName != "Added")
            .Select(c => $"{c.ColumnName} LIKE '%{this.SearchPattern}%'"));

        private readonly ObservableCollection<DiscogsSearchResult> searchResults = new ObservableCollection<DiscogsSearchResult>();

        private readonly ObservableCollection<DiscogsCollectionRelease> collectionResults = new ObservableCollection<DiscogsCollectionRelease>();

        #endregion

        #region public properties

        public string SearchPattern
        {
            get => (string)this.GetValue(SearchPatternProperty);
            set => this.SetValue(SearchPatternProperty, value);
        }

        public static readonly DependencyProperty SearchPatternProperty = DependencyProperty.Register(
            nameof(SearchPattern), typeof(string), typeof(HomeViewControlModel), new PropertyMetadata());

        public bool InCollection
        {
            get => (bool)this.GetValue(InCollectionProperty);
            set => this.SetValue(InCollectionProperty, value);
        }

        public static readonly DependencyProperty InCollectionProperty = DependencyProperty.Register(
            nameof(InCollection), typeof(bool), typeof(HomeViewControlModel), new PropertyMetadata());
        public DiscogsIdentity User;

        public DiscogsEntity SelectedEntity
        {
            get => this.selectedEntity;
            set
            {
                this.selectedEntity = value;
                this.SelectedEntityChanged?.Invoke();
            }
        }

        public readonly DataTable ResultsTable = new DataTable();

        public readonly DataTable CollectionTable = new DataTable();

        #endregion

        #region events & eventhandlers

        public delegate void SelectedEntityChangedEventHandler();

        public event Action UserChanged;

        public event SelectedEntityChangedEventHandler SelectedEntityChanged;

        #endregion

        public HomeViewControlModel()
        {
            DiscogsService.TokenChanged += this.discogsServiceOnTokenChanged;

            this.searchResults.CollectionChanged += this.searchResultsOnCollectionChanged;

            this.collectionResults.CollectionChanged += this.collectionResultsOnCollectionChanged;

            this.discogsServiceOnTokenChanged();
        }

        #region public methods

        public void SelectSearchResult(DataRow row)
        {
            Task.Run(() =>
            {
                switch ((DiscogsEntityType)Enum.Parse(typeof(DiscogsEntityType), row["Type"].ToString()))
                {
                    case DiscogsEntityType.release:
                        this.SelectedEntity = DiscogsService.GetRelease(int.Parse(row["Id"].ToString()));
                        break;
                    case DiscogsEntityType.master:
                        this.SelectedEntity = DiscogsService.GetMasterRelease(int.Parse(row["Id"].ToString()));
                        break;
                    case DiscogsEntityType.artist:
                        this.SelectedEntity = DiscogsService.GetArtist(int.Parse(row["Id"].ToString()));
                        break;
                    case DiscogsEntityType.label:
                        this.SelectedEntity = DiscogsService.GetLabel(int.Parse(row["Id"].ToString()));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }

        public void Search()
        {
            if (this.InCollection)
            {
                this.searchCollection();
            }
            else
            {
                this.searchDiscogs();
            }
        }

        public void GetCollection(bool overwrite = false)
        {
            this.CollectionTable.CaseSensitive = false;
            this.CollectionTable.Rows.Clear();
            this.CollectionTable.Columns.Clear();
            this.CollectionTable.Columns.AddRange(new[]
                {
                    new DataColumn("Title"),
                    new DataColumn("Artist"),
                    new DataColumn("Year"),
                    new DataColumn("Added", typeof(DateTime)),
                    new DataColumn("Type"),
                    new DataColumn("Id")
                });
            this.collectionResults.Clear();
            DiscogsService.GetCollectionReleases(this.collectionResults, overwrite);
        }

        public void DownloadCurrentList()
        {
            ExportAndDownloadHelper.ReleasesHelp(this.InCollection
                ? this.CollectionTable.Select(this.collectionSearchPattern)
                : this.ResultsTable.Rows.Cast<DataRow>(), Help.Download);
        }

        public void ExportCurrentList()
        {
            ExportAndDownloadHelper.ReleasesHelp(this.InCollection
                ? this.CollectionTable.Select(this.collectionSearchPattern)
                : this.ResultsTable.Rows.Cast<DataRow>(), Help.Export);
        }

        #endregion

        #region private methods

        private void discogsServiceOnTokenChanged()
        {
            Task.Run(() =>
            {
                this.User = DiscogsService.GetUser();
                this.UserChanged?.Invoke();
            });
        }

        private void searchDiscogs()
        {
            this.ResultsTable.Rows.Clear();
            this.ResultsTable.Columns.Clear();
            this.ResultsTable.Columns.AddRange(new[]
                {
                    new DataColumn("Title"),
                    new DataColumn("Type"),
                    new DataColumn("Id"),
                });
            this.searchResults.Clear();
            DiscogsService.Search(this.SearchPattern, this.searchResults);
        }

        private void searchCollection()
        {
            this.CollectionTable.DefaultView.RowFilter = this.collectionSearchPattern;
        }

        private void searchResultsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            foreach (DiscogsSearchResult searchResult in notifyCollectionChangedEventArgs.NewItems ?? new DiscogsSearchResult[0])
            {
                if (searchResult.type == DiscogsEntityType.master)
                {
                    return;
                }

                this.ResultsTable.Rows.Add(searchResult.title, searchResult.type, searchResult.id);
            }
        }

        private void collectionResultsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (DiscogsCollectionRelease collectionRelease in e.NewItems ?? new DiscogsRelease[0])
            {
                DataRow dataRow = this.CollectionTable.NewRow();

                dataRow["Title"] = collectionRelease.basic_information.title;
                dataRow["Artist"] = string.Join(", ", collectionRelease.basic_information.artists.Select(a => a.name));
                dataRow["Year"] = collectionRelease.basic_information.year;
                dataRow["Added"] = collectionRelease.date_added;
                dataRow["Type"] = "release";
                dataRow["Id"] = collectionRelease.id;

                if (collectionRelease.notes != null)
                {
                    DiscogsCustomField[] fields = DiscogsService.GetCustomFields();

                    foreach (DiscogsNote collectionReleaseNote in collectionRelease.notes)
                    {
                        DiscogsCustomField field = fields.FirstOrDefault(customField =>
                            customField.id == collectionReleaseNote.field_id);

                        if (field == null || field.name == "Media Condition" || field.name == "Sleeve Condition")
                        {
                            continue;
                        }

                        if (!this.CollectionTable.Columns.Contains(field.name))
                        {
                            this.CollectionTable.Columns.Add(field.name);
                        }

                        dataRow[field.name] = collectionReleaseNote.value;
                    }
                }

                this.CollectionTable.Rows.Add(dataRow);
            }
        }

        #endregion
    }
}