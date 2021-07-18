using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using F_Data.EFEntities;

#nullable disable

namespace F_Data
{
    public partial class AgroCampoContext : DbContext
    {
        public AgroCampoContext()
        {
        }

        public AgroCampoContext(DbContextOptions<AgroCampoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Persona { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("persona");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("documento");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
