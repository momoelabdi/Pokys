using Microsoft.EntityFrameworkCore;
using Pokys.Models.Domain;


namespace Pokys.Data       // Pokys.Data is the namespace of the project
{

  public class MVCDemoDbContext : DbContext
  {
    public MVCDemoDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Employee> Employees { get; set; }
  }
}


//    Momo@127.0.0.1:3306
// "Server=127.0.0.1:3306;Database=pokys;Uid=Momo;Pwd=password;"

