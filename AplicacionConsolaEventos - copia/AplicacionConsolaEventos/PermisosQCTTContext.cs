using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AplicacionConsolaEventos
{
    public partial class PermisosQCTTContext : DbContext
    {
        public PermisosQCTTContext()
        {
        }

        public PermisosQCTTContext(DbContextOptions<PermisosQCTTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Eventos> Eventos { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }

        public virtual DbSet<EventosComedor> EventosComedor { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=172.19.1.10;Database=PermisosQCTT;User ID=QCTDesarrollo;Password=QC7D354rr0110;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Celular).HasMaxLength(20);

                entity.Property(e => e.CorreoElectronico).HasMaxLength(100);

                entity.Property(e => e.CuentaRed).HasMaxLength(60);

                entity.Property(e => e.FechaNacimiento)
                    .IsRequired()
                    .HasMaxLength(21);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.NumeroExtension).HasMaxLength(20);
            });

            modelBuilder.Entity<Eventos>(entity =>
            {
               
                entity.Property(e => e.Fecha)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Hora)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tevento);
                
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.Property(e => e.FechaRegreso).HasMaxLength(22);

                entity.Property(e => e.FechaRegresoReal).HasMaxLength(22);

                entity.Property(e => e.FechaSalida).HasMaxLength(22);

                entity.Property(e => e.FechaSalidaReal).HasMaxLength(22);

                entity.Property(e => e.HoraRegreso).HasMaxLength(17);

                entity.Property(e => e.HoraRegresoReal).HasMaxLength(17);

                entity.Property(e => e.HoraSalida).HasMaxLength(13);

                entity.Property(e => e.HoraSalidaReal).HasMaxLength(13);

                entity.Property(e => e.Motivo).HasMaxLength(255);
            });

            modelBuilder.Entity<EventosComedor>()
             .Property(e => e.IdEmpleado)
             .IsUnicode(false);

            modelBuilder.Entity<EventosComedor>()
                .Property(e => e.Fecha)
                .IsUnicode(false);

            modelBuilder.Entity<EventosComedor>()
                .Property(e => e.Hora)
                .IsUnicode(false);


        }
    }
}
