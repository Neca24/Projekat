using BusinessLayer.Interfaces;
using BusinessLayer.ResultWrappers;
using BusinessLayer.Services.StateServices;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.Services
{
    public class IzdajeService:IIzdajeService
    {
        private readonly IIzdajeRepository _izdajeRepository;
        private readonly ILogger<IzdajeService> _logger;
        private readonly UserState _userState;
        private readonly SaveUrlService _saveUrlService;

        public IzdajeService(IIzdajeRepository izdajeRepository,ILogger<IzdajeService> logger,UserState userState,SaveUrlService saveUrlService)
        {
            _izdajeRepository = izdajeRepository ?? throw new ArgumentNullException(nameof(izdajeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userState = userState ?? throw new ArgumentNullException(nameof(userState));
            _saveUrlService = saveUrlService ?? throw new ArgumentNullException(nameof(saveUrlService));
        }

        public async Task<ResultWrapper> AddNewIzdajeAsync(Izdaje izdaje)
        {
            if(izdaje == null)
            {
                _logger.LogWarning("Pokusaj dodavanja null objekta u IzdajeService");
                return new ResultWrapper
                {
                    Message = "Cannot add a null entity to the database",
                    Success = false
                };
            }

            try
            {
                izdaje.VpisUporabnik = _userState.CurrentUserId;
                var res = await _izdajeRepository.AddAsync(izdaje);
                if (res)
                {
                    return new ResultWrapper
                    {
                        Message = "Row successfully added",
                        Success = true
                    };
                }
                else
                {
                    return new ResultWrapper
                    {
                        Message = "Failed to add row",
                        Success = false
                    };
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Greska prilikom dodavanja u Izdaje Business Layer");
                return new ResultWrapper
                {
                    Message = "Unexpected error occurred",
                    Success = false
                };
            }
        }

        public async Task<IEnumerable<Izdaje>> GetAllIzdaje(bool sortDescending)
        {
            try
            {
                var query = _izdajeRepository.GetAllQuery();

                query = sortDescending
                    ? query.OrderByDescending(q => q.Id)
                    : query.OrderBy(q => q.Id);

                _saveUrlService.ThisTrenutniSql = query.ToQueryString();
                return await query.AsNoTracking().ToListAsync();

            }catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja svih redova u Izdaje");
                return Enumerable.Empty<Izdaje>();
            }
        }

        //public async Task<IEnumerable<Izdaje>> GetAllIzdajeWithVoziloId(int voziloId)
        //{
        //    try
        //    {
        //        return await _izdajeRepository.GetAllWithVoziloId(voziloId);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e, "Greska prilikom vracanja izdaje sa id vozila: " + voziloId);
        //        throw;
        //    }
        //}

        public async Task<List<Izdaje>> GetAllQueryIzdaje(int filter)
        {
            try
            {
                var query = _izdajeRepository.GetAllQuery();
                if (filter == 0)
                {
                    return await query
                        .Include(i => i.Vozniki)
                        .Include(i => i.Vozila)
                        .Where(i => i.Status == 1 || i.Status == 2 || i.Status == 5 || i.Status == 6)
                        .OrderByDescending(i => i.VpisDatetime)
                        .ToListAsync();
                }
                else
                {
                    return await query
                        .Include(i => i.Vozniki)
                        .Include(i => i.Vozila)
                        .OrderByDescending(i => i.VpisDatetime)
                        .ToListAsync();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Greska u BL, query Izdaje");
                throw;
            }
        }

        public async Task<Izdaje?> GetIzdajeById(int izdajeId)
        {
            try
            {
                var izdaje = await _izdajeRepository.GetById(izdajeId);
                if (izdaje == null)
                {
                    _logger.LogInformation("Izdaje sa ID {izdajeId} nije pronadjen", izdajeId);
                }
                return izdaje;
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja Izdaje sa ID {izdajeId}", izdajeId);
                return null;
            }
        }

        public async Task<ResultWrapper> UpdateIzdajeAsync(Izdaje izdaje)
        {
            if (izdaje == null)
            {
                _logger.LogWarning("Pokusaj azuriranja null objekta IzdajeService");
                return new ResultWrapper 
                { 
                    Success = false, 
                    Message = "Entity is null" 
                };
            }
            try
            {
                izdaje.SprUporabnik = _userState.CurrentUserId;
                var res = await _izdajeRepository.UpdateAsync(izdaje);
                return res
                    ? new ResultWrapper { Success = true, Message = "Row successfully updated" }
                    : new ResultWrapper { Success = false, Message = "Failed to update row" };
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Neocekivana greska prilikom azuriranja Izdaje u BL");
                return new ResultWrapper { Success = false, Message = "Unexpected error occurred" };
            }
        }
    }
}
