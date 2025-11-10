using DataAccessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IUporabnikService
    {
        Task<Uporabniki> GetByUporabnikByUserName(string userName);
    }
}
