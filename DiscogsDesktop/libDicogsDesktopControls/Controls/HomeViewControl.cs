using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlModels;
using libDicogsDesktopControls.ControlSelector;
using libDicogsDesktopControls.Dialogs;
using libDicogsDesktopControls.Extensions;

namespace libDicogsDesktopControls.Controls
{
    public sealed partial class HomeViewControl : UserControl
    {
        private readonly HomeViewControlModel viewmodel = new HomeViewControlModel();

        public int TableFontSize
        {
            get => (int)this.dataGridView1.Font.Size;
            set => this.dataGridView1.Font = new Font(this.dataGridView1.Font.FontFamily, value);
        }

        public HomeViewControl()
        {
            this.InitializeComponent();
            this.TableFontSize = 15;
            GlobalControls.DiscogsEntityControlPanel = this.panelSelected;
            GlobalControls.SoundPlayerControl = this.soundPlayer1;
            this.textBoxSearchPattern.DataBindings.Add(new Binding(nameof(this.textBoxSearchPattern.Text), this.viewmodel, nameof(this.viewmodel.SearchPattern), true,
                DataSourceUpdateMode.OnPropertyChanged));
            this.radioButtonCollection.DataBindings.Add(new Binding(nameof(this.radioButtonCollection.Checked), this.viewmodel, nameof(this.viewmodel.InCollection), true,
                DataSourceUpdateMode.OnPropertyChanged));
            this.dataGridView1.DataSource = this.viewmodel.ResultsTable;
            this.viewmodel.SelectedEntityChanged += this.viewmodelOnSelectedEntityChanged;
            this.viewmodel.UserChanged += this.viewmodelOnUserChanged;
        }

        private void viewmodelOnUserChanged()
        {
            this.labelUserName.InvokeIfRequired(() => { this.labelUserName.Text = $"logged in as: {this.viewmodel.User?.username}"; });
            this.viewmodel.GetCollection();
        }

        private void viewmodelOnSelectedEntityChanged()
        {
            this.panelSelected.InvokeIfRequired(() =>
            {
                this.panelSelected.Controls.Clear();
                Control control = DiscogsEntityControlSelector.GetControl(this.viewmodel.SelectedEntity);
                this.panelSelected.Controls.Add(control);
                control.Dock = DockStyle.Fill;
            });
        }

        private void button1Click(object sender, EventArgs e)
        {
            this.viewmodel.Search();
        }

        private void dataGridView1SelectionChanged(object sender, EventArgs e)
        {
            this.panelSelected.Controls.Cast<Control>().FirstOrDefault()?.Dispose();

            if (this.dataGridView1.SelectedRows.Count != 1)
            {
                return;
            }

            this.viewmodel.SelectSearchResult(((DataRowView)this.dataGridView1.SelectedRows[0].DataBoundItem).Row);
        }

        private void textBoxSearchPatternKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
            {
                return;
            }

            e.Handled = true;
            this.viewmodel.Search();
        }

        private void radioButtonCollectionCheckedChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.radioButtonCollection.Checked ? this.viewmodel.CollectionTable : this.viewmodel.ResultsTable;
        }

        private void buttonDownloadAllReleasesInListClick(object sender, EventArgs e)
        {
            this.viewmodel.DownloadCurrentList();
        }

        private void buttonExportReleasesClick(object sender, EventArgs e)
        {
            this.viewmodel.ExportCurrentList();
        }
    }
}