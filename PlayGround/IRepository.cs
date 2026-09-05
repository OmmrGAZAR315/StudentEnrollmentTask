namespace PlayGround
{
    public delegate bool FilterCriteria<in T>(T item);

    internal interface IRepository<T>
    {
        void Add(T item);
        T? Get(string id);
        void Remove(string code);
        List<T> GetAll();
        List<T> Filter(FilterCriteria<T> criteria);
    }
}