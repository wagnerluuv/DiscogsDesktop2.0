using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libDiscogsDesktop.Helper
{
    public static class ProgressHelper
    {
        public static int GetProgressPercentage(int step, int all)
        {
            return (int)(step.toDouble() / all.toDouble() * 100);
        }
        
        private static double toDouble(this int number)
        {
            return number;
        }
    }
}
