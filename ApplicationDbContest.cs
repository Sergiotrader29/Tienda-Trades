using Microsoft.EntityFrameworkCore;
using TiendaAPi.Entidades;

namespace TiendaAPi
{
  
    public class ApplicationDbContest : DbContext
    {
        public ApplicationDbContest(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tienda>()
                .HasMany(t => t.Productos)
                .WithOne(p => p.Tienda)
                .HasForeignKey(p => p.TiendaID);
        }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Producto> Productos { get; set; }

       
    }
}
