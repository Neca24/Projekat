using BusinessLayer.ResultWrappers;
using DataAccessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IVoznikiService
    {
        Task<ResultWrapper> AddNewVozniki(Vozniki vozniki);
        Task<ResultWrapper> UpdateVozniki(Vozniki vozniki);
        Task<IEnumerable<Vozniki>> GetAllVozniki();
        Task<Vozniki?> GetVoznikiById(int voznikiId);
        Task<List<Vozniki>> GetAllQueryVozniki(int filter);
    }
}
