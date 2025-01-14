using System;
using Microsoft.EntityFrameworkCore;
using Seminario_Proyecto_II.Data.Models;

namespace Seminario_Proyecto_II.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Residente> Residentes { get; set; }
        public DbSet<PersonaRelacionada> PersonasRelacionadas { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Casa> Casas { get; set; }
        public DbSet<HistorialDeAcceso> HistorialDeAccesos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para Residente
            modelBuilder.Entity<Residente>()
                .Property(r => r.Nombres)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Residente>()
                .HasMany(r => r.Casas)
                .WithOne(c => c.Residente)
                .HasForeignKey(c => c.ResidenteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración para PersonaRelacionada
            modelBuilder.Entity<PersonaRelacionada>()
                .Property(p => p.Nombres)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Casa>()
                .HasMany(c => c.PersonasRelacionadas)
                .WithOne(p => p.Casa)
                .HasForeignKey(p => p.CasaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de claves primarias y relaciones adicionales
            modelBuilder.Entity<HistorialDeAcceso>()
                .HasKey(h => h.Id); // Asegura que haya una clave primaria definida en HistorialDeAcceso
        }
    }
}
