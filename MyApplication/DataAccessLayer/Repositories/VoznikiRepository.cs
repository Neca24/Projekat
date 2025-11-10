using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace DataAccessLayer.Repositories
{
    public class VoznikiRepository : IVoznikiRepository
    {
        private readonly BohovaContext _dbContext;
        private readonly ILogger<VoznikiRepository> _logger;
        public VoznikiRepository(BohovaContext dbContext,ILogger<VoznikiRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<bool> AddAsync(Vozniki entity)
        {
            if(entity == null)
            {
                _logger.LogInformation("Pokusaj dodavnja null objekta {@Entity}", entity);
                return false;
            }

            try
            {
                await _dbContext.Voznikis.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateException e)
            {
                _logger.LogError(e,"Greska prilikom dodavanja {@Entity}", entity);
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
                var entity = await _dbContext.Voznikis.FindAsync(entityId);
                if (entity == null)
                {
                    _logger.LogInformation("Nije pronadjeno Voznik sa ID: {entityId}", entityId);
                    return false;
                }

                _dbContext.Voznikis.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateException e)
            {
                _logger.LogError(e, "Greska prilikom brisanja Voznik sa ID: {entityId}", entityId);
                return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Neocekivana greska prilikom brisanja Voznik sa ID: " + entityId);
                return false;
            }
        }

        public async Task<IEnumerable<Vozniki>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Voznikis
                    .AsNoTracking()
                    .OrderBy(v=>v.Opis)
                    .ToListAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja svih redova iz tabele Vozniki");
                return Enumerable.Empty<Vozniki>();
            }
        }

        public IQueryable<Vozniki> GetAllQuery()
        {
            try
            {
                return _dbContext.Voznikis.AsNoTracking().AsQueryable();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja queryja u DAL Vozniki");
                return Enumerable.Empty<Vozniki>().AsQueryable();
            }
        }

        public async Task<Vozniki?> GetByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Voznikis
                    .AsNoTracking()
                    .FirstOrDefaultAsync(v => v.Id == id);
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja Voznik sa ID: {id}", id);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Vozniki entity)
        {
            if (entity == null)
            {
                _logger.LogWarning("Pokušaj azuriranja null entiteta u VoznikiRepository");
                return false;
            }

            try
            {
                _dbContext.Voznikis.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException e)
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
