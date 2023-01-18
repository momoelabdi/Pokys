using Microsoft.EntityFrameworkCore;
using Pokys.Models.Domain;

namespace Pokys.Data
{

  public class MVCDemoDbContext : DbContext
  {
    public MVCDemoDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Employee> Employees { get; set; }
  }
}
