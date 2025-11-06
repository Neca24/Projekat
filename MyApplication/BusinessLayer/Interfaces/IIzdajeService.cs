using BusinessLayer.ResultWrappers;
using DataAccessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IIzdajeService
    {
        Task<ResultWrapper> AddNewIzdajeAsync(Izdaje izdaje);
        Task<IEnumerable<Izdaje>> GetAllIzdaje(bool sortDescending);
        //Task<IEnumerable<Izdaje>> GetAllIzdajeWithVoziloId(int voziloId);
        Task<List<Izdaje>> GetAllQueryIzdaje(int filter);
        Task<Izdaje?> GetIzdajeById(int izdajeId);
        Task<ResultWrapper> UpdateIzdajeAsync(Izdaje izdaje);
    }
}
