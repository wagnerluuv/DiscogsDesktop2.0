using System;
using System.Drawing;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace libDicogsDesktopControls.ControlBase
{
    public partial class TypeTitleImageControl : UserControl
    {
        public string Title
        {
            get => this.labelTitle.Text;
            set => this.labelTitle.Text = value;
        }

        public string Type
        {
            get => this.labelType.Text;
            set => this.labelType.Text = value;
        }

        public Image Image
        {
            get => this.pictureBoxImage.Image;
            set => this.pictureBoxImage.Image = value;
        }

        public TypeTitleImageControl()
        {
            this.InitializeComponent();
        }
    }
}