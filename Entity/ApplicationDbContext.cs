using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProximaEnergia.Entity;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcuerdosComerciales> AcuerdosComerciales { get; set; }

    public virtual DbSet<AgentesComerciales> AgentesComerciales { get; set; }

    public virtual DbSet<TarifasAcuerdo> TarifasAcuerdos { get; set; }

    public virtual DbSet<TarifasConsumo> TarifasConsumos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcuerdosComerciales>(entity =>
        {
            entity.HasKey(e => e.IdAcuerdo);

            entity.Property(e => e.Ambito)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.CodFormaPago)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdAgenteNavigation).WithMany(p => p.AcuerdosComerciales)
                .HasForeignKey(d => d.IdAgente)
                .HasConstraintName("FK_AcuerdosComerciales_AgentesComerciales");
        });

        modelBuilder.Entity<AgentesComerciales>(entity =>
        {
            entity.HasKey(e => e.IdAgente);

            entity.Property(e => e.Estado)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.NIF)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Nombre).HasMaxLength(200);
        });

        modelBuilder.Entity<TarifasAcuerdo>(entity =>
        {
            entity.HasKey(e => e.IdTarifaAcuerdo).HasName("PK_ComisionesComerciales_1");

            entity.Property(e => e.FechaVigor).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PorcRenovacion).HasDefaultValue(100);

            entity.HasOne(d => d.IdAcuerdoNavigation).WithMany(p => p.TarifasAcuerdos)
                .HasForeignKey(d => d.IdAcuerdo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ComisionesComerciales_AcuerdosComerciales1");

            entity.HasOne(d => d.IdTarifaNavigation).WithMany(p => p.TarifasAcuerdos)
                .HasForeignKey(d => d.IdTarifa)
                .HasConstraintName("FK_ComisionesComercialesAcuerdos_TarifasConsumo");
        });

        modelBuilder.Entity<TarifasConsumo>(entity =>
        {
            entity.HasKey(e => e.IdTarifa).HasName("TarifasConsumo_PK");

            entity.ToTable("TarifasConsumo");

            entity.Property(e => e.CodCanal)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CodTarifaAcceso)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.FinVigencia).HasColumnType("datetime");
            entity.Property(e => e.InicioVigencia).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
