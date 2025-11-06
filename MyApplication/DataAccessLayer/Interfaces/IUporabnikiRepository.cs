using DataAccessLayer.Models;

namespace DataAccessLayer.Interfaces
{
    public interface IUporabnikiRepository:IRepository<Uporabniki>
    {
        Task<Uporabniki?> GetByName(string name);
    }
}
