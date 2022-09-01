using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AccesoADatos.Modelos
{
    public partial class UniversidadABCContext : DbContext
    {
        public UniversidadABCContext()
        {
        }

        public UniversidadABCContext(DbContextOptions<UniversidadABCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignatura> Asignaturas { get; set; } = null!;

        //#warning To protect potentially sensitive information in your connection string,
        //you should move it out of source code. You can avoid scaffolding the connection
        //string by using the Name= syntax to read it from configuration
        //- see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on
        //storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-6F2GNN6S; Database=UniversidadABC; Trusted_Connection = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.HasKey(e => e.CodigoAsignatura)
                    .HasName("PK__Asignatu__D41994BA564AA6EF");

                entity.ToTable("Asignatura");

                entity.Property(e => e.CodigoAsignatura)
                    .HasMaxLength(50)
                    .HasColumnName("Codigo_Asignatura");

                entity.Property(e => e.CarreraProfesional)
                    .HasMaxLength(50)
                    .HasColumnName("Carrera_Profesional");

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.Creditos).HasMaxLength(50);

                entity.Property(e => e.Cuatrimestre).HasMaxLength(50);

                entity.Property(e => e.Docente).HasMaxLength(50);

                entity.Property(e => e.DuracionSemanas).HasColumnName("Duracion_Semanas");

                entity.Property(e => e.HorasSemanales).HasColumnName("Horas_Semanales");

                entity.Property(e => e.Inicio).HasColumnType("date");

                entity.Property(e => e.NombreAsignatura)
                    .HasMaxLength(50)
                    .HasColumnName("Nombre_Asignatura");

                entity.Property(e => e.Termino).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
