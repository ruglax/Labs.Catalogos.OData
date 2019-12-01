using Labs.Catalogos.OData.Models;
using Microsoft.EntityFrameworkCore;

namespace Labs.Catalogos.OData.DataAccess
{
    public class DbCatalogContext : DbContext
    {
        public DbCatalogContext(DbContextOptions<DbCatalogContext> options)
        : base(options)
        {

        }

        public DbSet<c_Aduana> Aduanas { get; set; }

        public DbSet<c_ClaveUnidad> ClavesUnindad { get; set; }

        public DbSet<c_CodigoPostal> CodigosPostales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<c_Aduana>().ToTable("c_Aduana").HasKey(p => p.Clave);
            modelBuilder.Entity<c_Aduana>().Property(p => p.Clave);
            modelBuilder.Entity<c_ClaveUnidad>().ToTable("c_ClaveUnidad").HasKey(p => p.Clave);
            modelBuilder.Entity<c_ClaveUnidad>().Property(p => p.Clave);
            modelBuilder.Entity<c_CodigoPostal>().ToTable("c_CodigoPostal").HasKey(p => p.Clave);
            modelBuilder.Entity<c_CodigoPostal>().Property(p => p.Clave);
            
        }
    }
}
