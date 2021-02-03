using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DiscogsClient.Data.Result;
using JetBrains.Annotations;
using libDicogsDesktopControls.ControlBase;
using libDicogsDesktopControls.ControlModels;
using libDicogsDesktopControls.Extensions;

namespace libDicogsDesktopControls.Controls
{
    public sealed partial class DiscogsLabelControl : TypeTitleImageControl
    {
        private readonly DiscogsLabelControlModel controlModel;

        public DiscogsLabelControl(DiscogsLabel label)
        {
            this.InitializeComponent();
            this.controlModel = new DiscogsLabelControlModel(label);
            this.DataBindings.Add(nameof(this.Title), this.controlModel, nameof(this.controlModel.Title), true, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxSearch.DataBindings.Add(nameof(this.textBoxSearch.Text), this.controlModel, nameof(this.controlModel.SearchPattern), true, DataSourceUpdateMode.OnPropertyChanged);
            this.controlModel.ImageLoaded += () => { this.InvokeIfRequired(() => { this.Image = this.controlModel.Image; }); };
            this.controlModel.SelectedReleaseChanged += this.controlModelOnSelectedReleaseChanged;
            this.dataGridViewReleases.DataSource = this.controlModel.ReleasesTable;
            this.controlModel.StartImageLoading();
        }

        private void controlModelOnSelectedReleaseChanged()
        {
            this.panelRelease.InvokeIfRequired(() =>
            {
                this.panelRelease.Controls.Clear();
                DiscogsReleaseControl control = new DiscogsReleaseControl(this.controlModel.SelectedRelease);
                this.panelRelease.Controls.Add(control);
                control.Dock = DockStyle.Fill;
            });
        }

        private void dataGridViewReleasesSelectionChanged(object sender, EventArgs e)
        {
            this.panelRelease.Controls.Cast<Control>().FirstOrDefault()?.Dispose();

            if (this.dataGridViewReleases.SelectedRows.Count != 1)
            {
                return;
            }

            this.controlModel.SelectRelease(((DataRowView)this.dataGridViewReleases.SelectedRows[0].DataBoundItem).Row);
        }

        private void textBoxSearchKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
            {
                return;
            }

            e.Handled = true;

            this.controlModel.Search();

        }

        private void buttonSearchClick(object sender, EventArgs e)
        {
            this.controlModel.Search();
        }

        private void linkLabelViewInbrowserLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.controlModel.ViewInBrowser();
        }

        private void buttonDownloadAllReleasesInListClick(object sender, EventArgs e)
        {
            this.controlModel.DownloadReleases();
        }

        private void buttonExportReleasesClick(object sender, EventArgs e)
        {
            this.controlModel.ExportReleases();
        }
    }
}