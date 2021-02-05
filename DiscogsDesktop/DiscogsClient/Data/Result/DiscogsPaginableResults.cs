namespace DiscogsClient.Data.Result
{
    public abstract class DiscogsPaginableResults<T>
    {
        public DiscogsPaginedResult pagination { get; set; }

        public abstract T[] GetResults();
    }

    public class DiscogsPaginableReleases<T> : DiscogsPaginableResults<T>
    {
        public T[] releases { get; set; }

        public override T[] GetResults()
        {
            return releases;
        }
    }
}
