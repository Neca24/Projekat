using BusinessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Interfaces;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Services
{
    public class UporabnikService:IUporabnikService
    {
        private readonly IUporabnikiRepository _uporabnikRepository;
        private readonly ILogger<UporabnikService> _logger;

        public UporabnikService(IUporabnikiRepository uporabnikiRepository, ILogger<UporabnikService> logger)
        {
            _uporabnikRepository = uporabnikiRepository ?? throw new ArgumentNullException(nameof(uporabnikiRepository));
            _logger = logger ?? throw new ArgumentNullException( nameof(logger));
        }
        public async Task<Uporabniki?> GetByUporabnikByUserName(string userName)
        {
            try
            {
                var uporabnik = await _uporabnikRepository.GetByName(userName);
                if(uporabnik == null)
                {
                    _logger.LogError("Uporabnik {userName} nije pronadjeno", userName);
                }
                return uporabnik;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Greska prilikom pretrage Uporabnik po korisnickom imenu u BL");
                return null;
            }
        }
    }
}
