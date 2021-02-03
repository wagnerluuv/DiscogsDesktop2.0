namespace DiscogsClient.Data.Result
{
    public abstract class DiscogsPaginableResults<T>
    {
        public DiscogsPaginedResult pagination { get; set; }

        public abstract T[] GetResults();
    }
}
