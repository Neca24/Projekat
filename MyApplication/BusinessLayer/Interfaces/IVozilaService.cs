using BusinessLayer.ResultWrappers;
using DataAccessLayer.Models;

namespace BusinessLayer.Interfaces
{
    public interface IVozilaService
    {
        Task<ResultWrapper> AddVoziloAsync(Vozila vozilo);
        Task<IEnumerable<Vozila>> GetAllVozila();
        Task<Vozila?> GetVoziloById(int voziloId);
        Task<ResultWrapper> UpdateVozilo(Vozila vozilo);
        Task<List<Vozila>> GetAllVozilaQuery();
    }
}
