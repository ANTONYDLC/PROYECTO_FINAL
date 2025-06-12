using HamburguesasTienda.Models;
using Microsoft.EntityFrameworkCore;

namespace HamburguesasTienda.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<CarritoItem> Carritos { get; set; }
        // Agrega más DbSets si tienes otras entidades, por ejemplo:
        // public DbSet<Orden> Ordenes { get; set; }
    }
}
