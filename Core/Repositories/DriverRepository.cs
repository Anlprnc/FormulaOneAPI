using FormulaOne.Data;
using FormulaOne.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Core.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ApiDbContext context, DbSet<Driver> dbSet, ILogger logger) : base(context, dbSet, logger)
        {
        }

        public override async Task<IEnumerable<Driver>> All()
        {
            try
            {
                return await _context.Drivers.Where(x => x.Id < 100).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public override async Task<Driver?> GetById(int id)
        {
            try
            {
                return await _context.Drivers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Driver?> GetByDriverNumber(int driverNumber)
        {
            try
            {
                return await _context.Drivers.FirstOrDefaultAsync(x => x.DriverNumber == driverNumber);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}