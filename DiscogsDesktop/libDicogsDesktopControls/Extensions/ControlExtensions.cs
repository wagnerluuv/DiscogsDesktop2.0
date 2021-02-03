using System;
using System.Windows.Forms;
using JetBrains.Annotations;

namespace libDicogsDesktopControls.Extensions
{
    public static class ControlExtensions
    {
        public static void InvokeIfRequired(this Control control, Action action, bool throwIfException = false)
        {
            try
            {
                if (control == null)
                {
                    return;
                }

                if (control.IsDisposed)
                {
                    return;
                }

                if (control.InvokeRequired)
                {
                    control.Invoke((MethodInvoker)action.Invoke);
                }
                else
                {
                    action.Invoke();
                }
            }
            catch
            {
                if (throwIfException)
                {
                    throw;
                }
            }
        }
    }
}