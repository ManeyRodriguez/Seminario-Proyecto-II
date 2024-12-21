using System;
using System.Collections.Generic;
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
        public DbSet<Casa> Casas { get; set; }
        public DbSet<PersonaRelacionada> PersonasRelacionadas { get; set; }
        public DbSet<CodigoDeAcceso> CodigosDeAcceso { get; set; }
        public DbSet<HistorialDeAcceso> HistorialDeAccesos { get; set; }
        public DbSet<Notificacion> Notificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones y restricciones
            modelBuilder.Entity<Residente>()
                .HasMany(r => r.Casas)
                .WithOne(c => c.Residente)
                .HasForeignKey(c => c.ResidenteId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Residente>()
                .HasMany(r => r.PersonasRelacionadas)
                .WithOne(p => p.Residente)
                .HasForeignKey(p => p.ResidenteId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Residente>()
                .HasMany(r => r.Notificaciones)
                .WithOne(n => n.Residente)
                .HasForeignKey(n => n.ResidenteId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<PersonaRelacionada>()
                .HasMany(p => p.CodigosDeAcceso)
                .WithOne(c => c.PersonaRelacionada)
                .HasForeignKey(c => c.PersonaId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<CodigoDeAcceso>()
                .HasMany(c => c.HistorialDeAccesos)
                .WithOne(h => h.CodigoDeAcceso)
                .HasForeignKey(h => h.CodigoId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
