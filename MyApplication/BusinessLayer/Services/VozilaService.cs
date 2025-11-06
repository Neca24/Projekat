using BusinessLayer.Interfaces;
using BusinessLayer.ResultWrappers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Services
{
    public class VozilaService : IVozilaService
    {
        private readonly IVozilaRepository _vozilaRepository;
        private readonly ILogger<VozilaService> _logger;

        public VozilaService(IVozilaRepository vozilaRepository,ILogger<VozilaService> logger)
        {
            _vozilaRepository = vozilaRepository ?? throw new ArgumentNullException(nameof(vozilaRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ResultWrapper> AddVoziloAsync(Vozila vozilo)
        {
            if(vozilo == null)
            {
                _logger.LogWarning("Pokusaj dodavanja null objekta VozilaService");
                return new ResultWrapper { Message= "Cannot add a null entity to the database",Success=false};
            }

            try
            {
                var res = await _vozilaRepository.AddAsync(vozilo);
                if (res)
                {
                    return new ResultWrapper
                    {
                        Success = true,
                        Message = "Row successfully added"
                    };
                }
                else
                {
                    _logger.LogError("Greska prilikom dodavanja Vozila u BL");
                    return new ResultWrapper
                    {
                        Success = false,
                        Message = "Failed to add row"
                    };
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom dodavanja u Vozila Business Layer");
                return new ResultWrapper
                {
                    Message = "Unexpected error occurred",
                    Success = false
                };
            }
            
        }

        public async Task<IEnumerable<Vozila>> GetAllVozila()
        {
            try
            {
                return await _vozilaRepository.GetAllAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom GetAllVozila u Business");
                return Enumerable.Empty<Vozila>();
            }
        }

        public async Task<List<Vozila>> GetAllVozilaQuery()
        {
            try
            {
                var query = _vozilaRepository.GetAllQuery();

                return await query.OrderBy(v=>v.Id).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Greska u BL, query Vozila");
                throw;
            }
        }

        public async Task<Vozila?> GetVoziloById(int voziloId)
        {
            try
            {
                var vozilo = await _vozilaRepository.GetById(voziloId);
                if(vozilo == null)
                {
                    _logger.LogError("Vozilo sa {voziloId} nije pronadjeno",voziloId);
                }
                return vozilo;

            }catch(Exception e)
            {
                _logger.LogError("Neocekivana greska prilikom pretrage vozila sa ID "+voziloId);
                return null;
            }
        }

        public async Task<ResultWrapper> UpdateVozilo(Vozila vozilo)
        {
            if(vozilo == null)
            {
                _logger.LogWarning("Pokusaj azuriranja null objekta u VoziloService");
                return new ResultWrapper { Success = false, Message = "Entity cannot be null" };
            }

            try
            {
                var res = await _vozilaRepository.UpdateAsync(vozilo);
                if (res)
                {
                    return new ResultWrapper
                    {
                        Message = "Row successfully updated",
                        Success = true
                    };
                }
                else
                {
                    return new ResultWrapper
                    {
                        Message = "Failed to update row",
                        Success = false
                    };
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Neocekivana greska prilikom azuriranja Vozila u BL");
                return new ResultWrapper
                {
                    Message = "Unexpected error occurred",
                    Success = false
                };
            }
        }
    }
}
