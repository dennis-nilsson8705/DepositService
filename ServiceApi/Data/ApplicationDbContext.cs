using ApiProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
 
    }

    public DbSet<Money> Money { get; set; }
}