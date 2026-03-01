namespace Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Add(T item);
        Task<T> Update(int id, T item);
        Task<T> Delete(int id);
    }
}
