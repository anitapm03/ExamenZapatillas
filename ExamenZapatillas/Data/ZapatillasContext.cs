using ExamenZapatillas.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenZapatillas.Data
{
    public class ZapatillasContext: DbContext
    {
        public ZapatillasContext(DbContextOptions<ZapatillasContext> options)
            : base(options) { }

        public DbSet<Zapatilla> Zapatillas { get; set; }
        public DbSet<ImagenZapatilla> Imagenes { get; set; }
        public DbSet<VistaZapas> VistaZapas { get; set; }
        public DbSet<VistaImagenes> VistaImagenes { get; set; }

    }
}
