using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Interfaces
{
    public interface IIzdajeRepository:IRepository<Izdaje>
    {
        Task<IEnumerable<Izdaje>> GetAllWithVoziloId(int voziloId);
        IQueryable<Izdaje> GetAllQuery();
        Task<Izdaje?> GetById(int izdajeId);
    }
}
