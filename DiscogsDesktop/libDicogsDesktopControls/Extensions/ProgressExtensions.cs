using System;
using System.Windows.Forms;
using JetBrains.Annotations;
using libDiscogsDesktop.Tasks;

namespace libDicogsDesktopControls.Extensions
{
    public static class ProgressExtensions
    {
        public static ProgressBarStyle ProgressBarStyle(this TaskProgress progress)
        {
            return progress.Determinate ? System.Windows.Forms.ProgressBarStyle.Continuous : System.Windows.Forms.ProgressBarStyle.Marquee;
        }
    }
}