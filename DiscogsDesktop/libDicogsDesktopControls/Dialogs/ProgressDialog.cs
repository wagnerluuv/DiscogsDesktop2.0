using System;
using System.Windows.Forms;
using JetBrains.Annotations;
using libDicogsDesktopControls.Extensions;

namespace libDicogsDesktopControls.Dialogs
{
    public sealed partial class ProgressDialog : Form
    {
        public string InfoText
        {
            get => this.labelInfo.Text;
            set => this.labelInfo.Text = value;
        }

        public ProgressDialog()
        {
            this.InitializeComponent();
        }

        public void SetProgress(int percentage)
        {
            percentage = percentage > 100 ? 100 : percentage < 0 ? 0 : percentage;

            if (percentage == 100)
            {
                this.InvokeIfRequired(this.Close);
                return;
            }

            this.progressBar.InvokeIfRequired(() => { this.progressBar.Value = percentage; });
        }
    }
}