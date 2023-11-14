using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Models;

public partial class PruebasContext : DbContext
{
    public PruebasContext()
    {
    }

    public PruebasContext(DbContextOptions<PruebasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.IdentificacionCompleta)
                .HasMaxLength(112)
                .IsUnicode(false)
                .HasComputedColumnSql("(concat([tp_identificacion],[no_identificacion]))", false)
                .HasColumnName("identificacion_completa");
            entity.Property(e => e.NoIdentificacion).HasColumnName("no_identificacion");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComputedColumnSql("(concat([nombres],[apellidos]))", false)
                .HasColumnName("nombre_completo");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.TpIdentificacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tp_identificacion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Usuario");

            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Pass)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pass");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
