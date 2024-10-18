using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tesis.Server.Models;

public partial class TesisContext : DbContext
{
    public TesisContext()
    {
    }

    public TesisContext(DbContextOptions<TesisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mascota> Mascota { get; set; }
    public virtual DbSet<Cliente> Cliente{ get; set; }
    public virtual DbSet<Historial> Historial{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Descripcion).HasMaxLength(90);
            entity.Property(e => e.Dueno).HasMaxLength(90);
            entity.Property(e => e.Nombre).HasMaxLength(90);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {   
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Correo);
            entity.Property(e => e.Contrasenia);
            entity.Property(e => e.Nombres);
            entity.Property(e => e.Direccion);
            entity.Property(e => e.Celular);
            entity.Property(e => e.RolUser);
        });

        modelBuilder.Entity<Historial>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Descripcion);
            entity.Property(e => e.Fecha);
            entity.Property(e => e.IdMascota);
            entity.Property(e => e.IdCliente);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
