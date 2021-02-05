using System;

namespace DiscogsClient.Data.Result
{
    public class DiscogsCollectionRelease : DiscogsEntity
    {
        public DateTime date_added { get; set; }

        public DiscogsRelease basic_information { get; set; }

        public DiscogsNote[] notes { get; set; }
    }
}