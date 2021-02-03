using System;

namespace DiscogsClient.Data.Result
{
    public class DiscogsReleases : DiscogsPaginableResults<DiscogsRelease>
    {
        public DiscogsRelease[] releases { get; set; }

        public override DiscogsRelease[] GetResults()
        {
            return this.releases;
        }
    }
}