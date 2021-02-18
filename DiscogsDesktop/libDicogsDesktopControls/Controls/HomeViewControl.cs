using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using libDicogsDesktopControls.ControlModels;
using libDicogsDesktopControls.ControlSelector;
using libDicogsDesktopControls.Extensions;

namespace libDicogsDesktopControls.Controls
{
    public sealed partial class HomeViewControl : UserControl
    {
        private readonly HomeViewControlModel viewmodel = new HomeViewControlModel();

        public HomeViewControl()
        {
            InitializeComponent();
            TableFontSize = 15;
            GlobalControls.DiscogsEntityControlPanel = panelSelected;
            GlobalControls.SoundPlayerControl = soundPlayer1;
            textBoxSearchPattern.DataBindings.Add(new Binding(nameof(textBoxSearchPattern.Text), viewmodel,
                nameof(viewmodel.SearchPattern), true,
                DataSourceUpdateMode.OnPropertyChanged));
            radioButtonCollection.DataBindings.Add(new Binding(nameof(radioButtonCollection.Checked), viewmodel,
                nameof(viewmodel.InCollection), true,
                DataSourceUpdateMode.OnPropertyChanged));
            dataGridView1.DataSource = viewmodel.ResultsTable;
            viewmodel.SelectedEntityChanged += viewmodelOnSelectedEntityChanged;
            viewmodel.UserChanged += viewmodelOnUserChanged;
        }

        public int TableFontSize
        {
            get => (int) dataGridView1.Font.Size;
            set => dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, value);
        }

        public void SyncCollection()
        {
            viewmodel.GetCollection(true);
        }

        private void viewmodelOnUserChanged()
        {
            labelUserName.InvokeIfRequired(() => { labelUserName.Text = $"logged in as: {viewmodel.User?.username}"; });
            viewmodel.GetCollection();

            dataGridView1.InvokeIfRequired(() =>
            {
                // ReSharper disable once PossibleNullReferenceException
                if (dataGridView1.Columns.Contains("Type"))
                    dataGridView1.Columns["Type"].Visible = false;
                // ReSharper disable once PossibleNullReferenceException
                if (dataGridView1.Columns.Contains("Id"))
                    dataGridView1.Columns["Id"].Visible = false;
            });
        }

        private void viewmodelOnSelectedEntityChanged()
        {
            panelSelected.InvokeIfRequired(() =>
            {
                panelSelected.Controls.Clear();
                Control control = DiscogsEntityControlSelector.GetControl(viewmodel.SelectedEntity);
                panelSelected.Controls.Add(control);
                control.Dock = DockStyle.Fill;
            });
        }

        private void button1Click(object sender, EventArgs e)
        {
            viewmodel.Search();
        }

        private void dataGridView1SelectionChanged(object sender, EventArgs e)
        {
            panelSelected.Controls.Cast<Control>().FirstOrDefault()?.Dispose();

            if (dataGridView1.SelectedRows.Count != 1) return;

            viewmodel.SelectSearchResult(((DataRowView) dataGridView1.SelectedRows[0].DataBoundItem).Row);
        }

        private void textBoxSearchPatternKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) Keys.Enter) return;

            e.Handled = true;
            viewmodel.Search();
        }

        private void radioButtonCollectionCheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource =
                radioButtonCollection.Checked ? viewmodel.CollectionTable : viewmodel.ResultsTable;
        }

        private void buttonDownloadAllReleasesInListClick(object sender, EventArgs e)
        {
            viewmodel.DownloadCurrentList();
        }

        private void buttonExportReleasesClick(object sender, EventArgs e)
        {
            viewmodel.ExportCurrentList();
        }
    }
}