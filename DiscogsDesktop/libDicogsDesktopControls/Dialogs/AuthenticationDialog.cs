using System;
using System.Diagnostics;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace libDicogsDesktopControls.Dialogs
{
    public sealed partial class AuthenticationDialog : Form
    {
        public string AuthenticationCode
        {
            get => this.textBoxCode.Text;
            set => this.textBoxCode.Text = value;
        }

        public AuthenticationDialog()
        {
            this.InitializeComponent();
        }

        private void buttonAuthorizeClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBoxCode.Text))
            {
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void linkLabel1LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.discogs.com/settings/developers");
        }
    }
}