using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositories
{
    public class VozilaRepository : IVozilaRepository
    {
        private readonly BohovaContext _dbContext;
        private readonly ILogger<VozilaRepository> _logger;

        public VozilaRepository(BohovaContext dbContext,ILogger<VozilaRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> AddAsync(Vozila entity)
        {
            if(entity == null)
            {
                _logger.LogInformation("Pokusaj dodavanja null entiteta u VozilaRepository");
                return false;
            }

            try
            {
                await _dbContext.Vozilas.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateException e)
            {
                _logger.LogError(e, "Greska prilikom dodavanja {@Entity}", entity);
                return false;
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Neocekivana greska prilikom dodavanja {@Entity}",entity);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int entityId)
        {
            try
            {
                var entity = await _dbContext.Vozilas.FindAsync(entityId);
                if(entity == null)
                {
                    _logger.LogInformation("Nije pronadjeno Vozilo sa ID: {entityId}", entityId);
                    return false;
                }
                _dbContext.Vozilas.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateException e)
            {
                _logger.LogError(e, "Greska prilikom brisanja Vozila sa ID: {entityId}", entityId);
                return false;
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Neocekivana greska prilikom brisanja Vozila sa ID: {entityId}",entityId);
                return false;
            }
        }

        public async Task<IEnumerable<Vozila>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Vozilas
                    .AsNoTracking()
                    .OrderBy(v => v.Opis)
                    .ToListAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja svih redova iz tabele Vozila");
                return Enumerable.Empty<Vozila>();
            }
        }

        public IQueryable<Vozila> GetAllQuery()
        {
            try
            {
                return _dbContext.Vozilas.AsNoTracking().AsQueryable();
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja queryja u DAL Vozika");
                return Enumerable.Empty<Vozila>().AsQueryable();
            }
        }

        public async Task<Vozila?> GetById(int voziloId)
        {
            try
            {
                return await _dbContext.Vozilas
                    .AsNoTracking()
                    .FirstOrDefaultAsync(v => v.Id == voziloId);
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja vozila sa ID: {voziloId}", voziloId);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Vozila entity)
        {
            if(entity == null)
            {
                _logger.LogInformation("Pokusaj azuriranja null objekta {@Entity}", entity);
                return false;
            }

            try
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateConcurrencyException e)
            {
                _logger.LogError(e, "Greska konkurentnog azuriranja {@Entity}", entity);
                return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Neocekivana greska prilikom azuriranja {@Entity}", entity);
                return false;
            }
        }
    }
}
