using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DepositService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Deposit>? Deposit { get; set; }
    }
}