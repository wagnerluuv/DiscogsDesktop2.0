using System;
using System.Drawing;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace libDicogsDesktopControls.ControlBase
{
    public partial class LeftToRightDockingControl : UserControl
    {
        public LeftToRightDockingControl()
        {
            this.InitializeComponent();
        }

        private void leftToRightDockingControlParentChanged(object sender, EventArgs e)
        {
            if (this.Parent == null)
            {
                return;
            }

            this.Parent.ClientSizeChanged += this.parentOnSizeChanged;
        }

        private void parentOnSizeChanged(object sender, EventArgs e)
        {
            Size? size = ((Control)sender)?.ClientSize;

            if (!size.HasValue)
            {
                return;
            }

            this.Size = new Size(size.Value.Width, this.Size.Height);
        }
    }
}