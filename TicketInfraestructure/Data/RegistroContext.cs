using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RegistroInfraestructure.Data
{
    public partial class RegistroContext : DbContext
    {
        public RegistroContext()
        {
        }

        public RegistroContext(DbContextOptions<RegistroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__Persona__F2374EB1D612D94A");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.IdentificacionCompleta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([NumeroIdentificacion]+[TipoIdentificacion])");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(([Nombres]+' ')+[Apellidos])");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97EECFD4E9");

                entity.HasIndex(e => e.FkPersona)
                    .HasName("UQ__Usuario__1B849BF0988E2612")
                    .IsUnique();

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FkPersona).HasColumnName("fk_Persona");

                entity.Property(e => e.Pass)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasColumnName("Usuario")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkPersonaNavigation)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(d => d.FkPersona)
                    .HasConstraintName("FK__Usuario__fk_Pers__276EDEB3");
            });

        }

    }
}
