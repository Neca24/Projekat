using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace DataAccessLayer.Repositories
{
    public class IzdajeRepository : IIzdajeRepository
    {
        private readonly BohovaContext _dbContext;
        private readonly ILogger<IzdajeRepository> _logger;

        public IzdajeRepository(BohovaContext dbContext, ILogger<IzdajeRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> AddAsync(Izdaje entity)
        {
            if (entity == null) 
            {
                _logger.LogWarning("Pokusaj dodavanja null entiteta u IzdajeRepository");
                return false;
            }
            try
            {
                await _dbContext.Izdajes.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException e)
            {
                _logger.LogError(e, "Greska u bazi prilikom dodavanja {@Entity}", entity);
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
                var entity = await _dbContext.Izdajes.FindAsync(entityId);
                if (entity==null)
                {
                    _logger.LogInformation("Nije pronadjen Izdaje sa ID {EntityId}", entityId);
                    return false;
                }
                _dbContext.Izdajes.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateException e)
            {
                _logger.LogError(e, "Greska u bazi prilikom brisanja Izdaje sa ID {EntityId}", entityId);
                return false;
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Neocekivana greska prilikom brisanja Izdaje sa ID {EntityId}",entityId);
                return false;
            }
        }

        public async Task<IEnumerable<Izdaje>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Izdajes
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja svih redova iz Izdaje tabele");
                return Enumerable.Empty<Izdaje>();
            }
        }
        public IQueryable<Izdaje> GetAllQuery()
        {
            try
            {
                return _dbContext.Izdajes.AsNoTracking().AsQueryable();
            }catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja queryja u DAL Izdaje");
                return Enumerable.Empty<Izdaje>().AsQueryable();
            }
        }

        public async Task<IEnumerable<Izdaje>> GetAllWithVoziloId(int voziloId)
        {
            try
            {
                return await _dbContext.Izdajes
                    .AsNoTracking()
                    .Include(i => i.Vozilo)
                    .Where(i=>i.Vozilo==voziloId)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja Izdaje sa VoziloId");
                return Enumerable.Empty<Izdaje>();
            }
        }

        public async Task<Izdaje?> GetById(int izdajeId)
        {
            try
            {
                return await _dbContext.Izdajes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.Id == izdajeId);
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja Izdaje sa ID: "+izdajeId);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Izdaje entity)
        {
            if (entity == null)
            {
                _logger.LogInformation("Pokusaj azuriranja null entiteta u IzdajeRepository");
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
            catch(Exception e)
            {
                _logger.LogError(e, "Neocekivana greska u bazi prilikom azuriranja {@Entity}", entity);
                return false;
            }
        }
    }
}
