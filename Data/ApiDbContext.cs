using FormulaOne.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Driver> Drivers { get; set; }
    }
}