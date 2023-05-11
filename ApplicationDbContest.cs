using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TiendaAPi.Models;

namespace TiendaAPi
{
    public class ApplicationDbContest : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContest(DbContextOptions<ApplicationDbContest> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
