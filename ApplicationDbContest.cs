using Microsoft.EntityFrameworkCore;
using TiendaAPi.Entidades;

namespace TiendaAPi
{
  
    public class ApplicationDbContest : DbContext
    {
        public ApplicationDbContest(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Producto> Productos { get; set; }

       
    }
}
