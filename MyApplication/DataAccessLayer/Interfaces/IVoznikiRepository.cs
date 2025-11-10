using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IVoznikiRepository : IRepository<Vozniki>
    {
        Task<Vozniki?> GetByIdAsync(int id);
        IQueryable<Vozniki> GetAllQuery();
    }
}
