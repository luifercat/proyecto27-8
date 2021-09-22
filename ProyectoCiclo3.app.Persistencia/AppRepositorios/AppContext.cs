using Microsoft.EntityFrameworkCore;
using ProyectoCiclo3.app.Dominio;

namespace ProyectoCiclo3.app.Persistencia
{
    public class AppContext: DbContext{
        public DbSet<Encomienda> Encomiendas {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Servicios> Servicios {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ProyectoCiclo3");
            }
        }
    }
}
