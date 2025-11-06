using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly BohovaContext _dbContext;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(BohovaContext dbContext, ILogger<ClientRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> AddAsync(Client entity)
        {
            if(entity == null)
            {
                _logger.LogWarning("Pokusaj dodavanja null entiteta u ClientRepository");
                return false;
            }
            try
            {
                await _dbContext.Clients.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException e)
            {
                _logger.LogError(e, "Greska prilikom dodavanja {@Entity}", entity);
                return false;
            }
            catch(Exception e)
            {
                _logger.LogError(e, "Neocekivana greska prilikom dodavanja {@Entity}", entity);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int entityId)
        {
            try
            {
                var entity = await _dbContext.Clients.FindAsync(entityId);
                if (entity == null)
                {
                    _logger.LogInformation("Nije pronadjen Client sa ID {entityId}", entityId);
                    return false;
                }

                _dbContext.Clients.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateException e)
            {
                _logger.LogError(e, "Greska u bazi prilikom brisanja Client sa ID {entityId}", entityId);
                return false;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Neocekivana greska prilikom brisanja Client sa ID {entityId}",entityId);
                return false;
            }
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Clients.AsNoTracking().ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja svih redova iz Client tabele");
                return Enumerable.Empty<Client>();
            }
        }

        public async Task<bool> UpdateAsync(Client entity)
        {
            if (entity == null)
            {
                _logger.LogWarning("Pokusaj azuriranja null entiteta u ClientRepository");
                return false;
            }
            try
            {
                _dbContext.Clients.Update(entity);
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
                _logger.LogError(e, "Neocekivana greska prilikom azuriranja {@Entity}", entity);
                return false;
            }
        }
    }
}
