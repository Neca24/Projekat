using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace DataAccessLayer.Repositories
{
    public class UporabnikiRepository:IUporabnikiRepository
    {
        private readonly BohovaContext _dbContext;
        private readonly ILogger<UporabnikiRepository> _logger;

        public UporabnikiRepository(BohovaContext dbContext,ILogger<UporabnikiRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> AddAsync(Uporabniki entity)
        {
            try
            {
                await _dbContext.Uporabnikis.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom dodavanja novog reda u {@Entity}", entity);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int entityId)
        {
            try
            {
                var entity = await _dbContext.Uporabnikis.FindAsync(entityId);
                if (entity!=null)
                {
                    _dbContext.Uporabnikis.Remove(entity);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom brisanja reda iz tabele Uporabniki sa ID: " + entityId);
                return true;
            }
        }

        public async Task<IEnumerable<Uporabniki>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Uporabnikis.AsNoTracking().ToListAsync();
            }catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom vracanja svih redova iz tabele Uporabniki");
                return Enumerable.Empty<Uporabniki>();
            }
        }

        public async Task<Uporabniki?> GetByName(string name)
        {
            try
            {
                return await _dbContext.Uporabnikis
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Userid == name);
            }
            catch(Exception e)
            {
                _logger.LogError(e,"Greska prilikom vracanja Uporabnik USERNAME: {name}", name);
                return null;
            }
        }

        public async Task<bool> UpdateAsync(Uporabniki entity)
        {
            try
            {
                _dbContext.Uporabnikis.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }catch(Exception e)
            {
                _logger.LogError(e, "Greska prilikom azuriranja u {@Entity}", entity);
                return false;
            }
        }
    }
}
