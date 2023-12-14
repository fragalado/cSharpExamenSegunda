using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL;

/// <summary>
/// Clase Contexto de la BD
/// </summary>
/// <autor>Puesto 8 (Fran Gallego)</autor>
/// Fecha: 14/12/2023
public partial class ExaDosContext : DbContext
{
    public ExaDosContext(DbContextOptions<ExaDosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<RelElementoReserva> RelElementoReservas { get; set; }

    public virtual DbSet<Vajilla> Vajillas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:Connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.Idreserva).HasName("prestamos_pkey");

            entity.ToTable("prestamos", "esqexados");

            entity.Property(e => e.Idreserva)
                .HasDefaultValueSql("nextval('prestamos_idreserva_seq'::regclass)")
                .HasColumnName("idreserva");
            entity.Property(e => e.Fchreserva)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fchreserva");
        });

        modelBuilder.Entity<RelElementoReserva>(entity =>
        {
            entity.HasKey(e => e.Idrelacion).HasName("rel_elemento_reserva_pkey");

            entity.ToTable("rel_elemento_reserva", "esqexados");

            entity.Property(e => e.Idrelacion)
                .HasDefaultValueSql("nextval('rel_elemento_reserva_idrelacion_seq'::regclass)")
                .HasColumnName("idrelacion");
            entity.Property(e => e.Cantidadelemento).HasColumnName("cantidadelemento");
            entity.Property(e => e.Idelemento).HasColumnName("idelemento");
            entity.Property(e => e.Idreserva).HasColumnName("idreserva");

            entity.HasOne(d => d.IdelementoNavigation).WithMany(p => p.RelElementoReservas)
                .HasForeignKey(d => d.Idelemento)
                .HasConstraintName("fk_rel_elemento_reserva_idelemento");

            entity.HasOne(d => d.IdreservaNavigation).WithMany(p => p.RelElementoReservas)
                .HasForeignKey(d => d.Idreserva)
                .HasConstraintName("fk_rel_elemento_reserva_idreserva");
        });

        modelBuilder.Entity<Vajilla>(entity =>
        {
            entity.HasKey(e => e.Idelemento).HasName("vajillas_pkey");

            entity.ToTable("vajillas", "esqexados");

            entity.Property(e => e.Idelemento)
                .HasDefaultValueSql("nextval('vajillas_idelemento_seq'::regclass)")
                .HasColumnName("idelemento");
            entity.Property(e => e.Cantidadelemento).HasColumnName("cantidadelemento");
            entity.Property(e => e.Codigoelemento)
                .HasMaxLength(255)
                .HasColumnName("codigoelemento");
            entity.Property(e => e.Descripcionelemento)
                .HasMaxLength(255)
                .HasColumnName("descripcionelemento");
            entity.Property(e => e.Nombreelemento)
                .HasMaxLength(255)
                .HasColumnName("nombreelemento");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
