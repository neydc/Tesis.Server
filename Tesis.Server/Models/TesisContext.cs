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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mascota>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion).HasMaxLength(50);
            entity.Property(e => e.Dueno).HasMaxLength(50);
            entity.Property(e => e.Nombre)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
