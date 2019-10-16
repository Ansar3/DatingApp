 using Microsoft.EntityFrameworkCore;
 using DatingApp.API.models;
namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
  
    }
              public DbSet<Value> values {get;set;}
              public DbSet<User> Users{get;set;}

    }
}