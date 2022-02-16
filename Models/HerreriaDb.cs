

using Microsoft.EntityFrameworkCore;

namespace Herreria_web.Models
{
    public class HerreriaDb : DbContext
    {
         public HerreriaDb(DbContextOptions<HerreriaDb> options)
        : base(options)
        { }
        public DbSet<CategoriaModel> CatDB {get;set;}
        public DbSet<ProductoModel> ProDB{get;set;}
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("HerreriaDB");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}