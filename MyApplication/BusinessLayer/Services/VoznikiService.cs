using BusinessLayer.Interfaces;
using BusinessLayer.ResultWrappers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Services
{
    public class VoznikiService:IVoznikiService
    {
        private readonly IVoznikiRepository _voznikiRepository;
        private readonly ILogger<VoznikiService> _logger;

        public VoznikiService(IVoznikiRepository voznikiRepository, ILogger<VoznikiService> logger)
        {
            _voznikiRepository = voznikiRepository ?? throw new ArgumentNullException(nameof(voznikiRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ResultWrapper> AddNewVozniki(Vozniki vozniki)
        {
            if(vozniki == null)
            {
                _logger.LogWarning("Pokusaj dodavanja null objekta u VoznikiService");
                return new ResultWrapper
                {
                    Message = "Cannot add a null entity to the database",
                    Success = false
                };
            }

            try
            {
                var res = await _voznikiRepository.AddAsync(vozniki);
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
                    _logger.LogError("Greska prilikom dodavanja Voznik u BL");
                    return new ResultWrapper
                    {
                        Success = false,
                        Message = "Failed to add row"
                    };
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom dodavanja u Voznik Business Layer");
                return new ResultWrapper
                {
                    Message = "Unexpected error occurred",
                    Success = false
                };
            }
        }

        public async Task<List<Vozniki>> GetAllQueryVozniki(int filter)
        {
            try
            {
                var query = _voznikiRepository.GetAllQuery();
                if (filter == 0)
                    return await query.OrderBy(v => v.Opis).ToListAsync();
                else
                    return await query.Where(v => v.Prikaz == true).ToListAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Greska u BL, query Vozniki");
                throw;
            }
        }

        public async Task<IEnumerable<Vozniki>> GetAllVozniki()
        {
            try
            {
                return await _voznikiRepository.GetAllAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e,"Greska BL vracanje svih vozniki");
                return Enumerable.Empty<Vozniki>();
            }
        }

        public async Task<Vozniki?> GetVoznikiById(int voznikiId)
        {
            try
            {
                var voznik = await _voznikiRepository.GetByIdAsync(voznikiId);
                if (voznik == null)
                {
                    _logger.LogError("Voznik sa {voznikId} nije pronadjen", voznikiId);
                }
                return voznik;

            }
            catch (Exception e)
            {
                _logger.LogError("Neocekivana greska prilikom pretrage Voznik sa ID " + voznikiId);
                return null;
            }
        }

        public async Task<ResultWrapper> UpdateVozniki(Vozniki vozniki)
        {
            if (vozniki == null)
            {
                _logger.LogWarning("Pokusaj azuriranja null objekta u VoznikService");
                return new ResultWrapper { Success = false, Message = "Entity cannot be null" };
            }

            try
            {
                var res = await _voznikiRepository.UpdateAsync(vozniki);
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
            catch (Exception e)
            {
                _logger.LogError(e, "Neocekivana greska prilikom azuriranja Voznik u BL");
                return new ResultWrapper
                {
                    Message = "Unexpected error occurred",
                    Success = false
                };
            }
        }
    }
}
