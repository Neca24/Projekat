using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer.Repositories
{
    public class VrstePlinaRepository : IVrstePlinaRepostiory
    {
        private readonly BohovaContext _dbContext;
        private readonly ILogger<VrstePlinaRepository> _logger;

        public VrstePlinaRepository(BohovaContext dbContext, ILogger<VrstePlinaRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<bool> AddAsync(VrstePlina entity)
        {
            try
            {
                await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom dodavanja novog reda u {@Entity}",entity);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int entityId)
        {
            try
            {
                var entity = await _dbContext.VrstePlinas.FindAsync(entityId);
                if (entity != null)
                {
                    _dbContext.VrstePlinas.Remove(entity);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom brisanja reda iz tabele VrstePlina sa ID: " + entityId);
                return false;
            }
        }

        public async Task<IEnumerable<VrstePlina>> GetAllAsync()
        {
            try
            {
                return await _dbContext.VrstePlinas.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja svih redova iz tabele VrstePlina");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(VrstePlina entity)
        {
            try
            {
                _dbContext.VrstePlinas.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom azuriranja podataka u {@Entity}", entity);
                return false;
            }
        }
    }
}
