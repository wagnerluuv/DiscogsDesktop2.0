using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscogsClient.Data.Result
{
    public class DiscogsCustomField
    {
        public string name { get; set; }

        public string[] options { get; set; }

        public int id { get; set; }

        public int position { get; set; }
    }

}
