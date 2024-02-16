using FormulaOne.Models;

namespace FormulaOne.Core
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        Task<Driver?> GetByDriverNumber(int driverNumber);
    }
}