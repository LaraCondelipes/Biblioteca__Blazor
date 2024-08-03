namespace Biblioteca_API.Repository
{
    public interface IRepository<T> 
    {
        IEnumerable<T> All();
        T? Get(int id);
        T Add(T entity);
        T Update(T entity);
        T Delete(int id);

    }
}
