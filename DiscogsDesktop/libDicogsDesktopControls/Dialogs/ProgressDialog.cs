using System;
using System.Windows.Forms;
using JetBrains.Annotations;
using libDicogsDesktopControls.Extensions;

namespace libDicogsDesktopControls.Dialogs
{
    public sealed partial class ProgressDialog : Form
    {
        private string originalInfotext;

        public string InfoText
        {
            get => this.originalInfotext;
            set
            {
                this.originalInfotext = value;   
                this.labelInfo.Text = value;
            } 
        }

        public ProgressDialog()
        {
            this.InitializeComponent();
        }

        public void SetProgress(int percentage)
        {
            this.SetProgress(percentage, -1, -1);
        }
        public void SetProgress(int percentage, int step , int all)
        {
            percentage = percentage > 100 ? 100 : percentage < 0 ? 0 : percentage;

            if (percentage == 100)
            {
                this.InvokeIfRequired(this.Close);
                return;
            }

            if (all > 0 && step > -1)
            {
                this.labelInfo.InvokeIfRequired(() =>
                {
                    this.labelInfo.Text = $@"{this.originalInfotext}   {step} / {all}";
                });
            }

            this.progressBar.InvokeIfRequired(() => { this.progressBar.Value = percentage; });
        }
    }
}