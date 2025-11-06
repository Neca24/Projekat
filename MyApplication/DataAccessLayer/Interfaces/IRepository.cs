namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int entityId);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
