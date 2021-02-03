using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscogsClient.Data.Result
{
    public class DiscogsCollectionReleases : DiscogsPaginableResults<DiscogsCollectionRelease>
    {
        public DiscogsCollectionRelease[] releases { get; set; }

        public override DiscogsCollectionRelease[] GetResults()
        {
            return releases;
        }
    }
}
