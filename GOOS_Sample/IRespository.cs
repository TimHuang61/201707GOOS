namespace GOOS_Sample
{
    public interface IRespository<T>
    {
        void Save(T entity);
    }
}