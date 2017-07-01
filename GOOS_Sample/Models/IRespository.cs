namespace GOOS_Sample.Models
{
    public interface IRespository<T>
    {
        void Save(T entity);
    }
}