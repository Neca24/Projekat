using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IVozilaRepository:IRepository<Vozila>
    {
        Task<Vozila?> GetById(int voziloId);
        IQueryable<Vozila> GetAllQuery();
    }
}
