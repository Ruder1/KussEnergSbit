using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TestCase.Models.DatabaseModels;

namespace TestCase.DataLoader;

/// <summary>
/// Данный класс сгенерирован автоматически при помощи EntityFrameWork
/// Необходим для взаимодействия между моделью бизнес логики и моделью базы данных
/// </summary>
public partial class BuisnessTestContext : DbContext
{
    public BuisnessTestContext()
    {
    }

    public BuisnessTestContext(DbContextOptions<BuisnessTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BuisnessProcess> BuisnessProcesses { get; set; }

    public virtual DbSet<CodeProcess> CodeProcesses { get; set; }

    public virtual DbSet<OwnerProcess> OwnerProcesses { get; set; }

    public virtual DbSet<Process> Processes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BuisnessTest");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BuisnessProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Buisness__3214EC079848C0F9");

            entity.HasOne(d => d.Code).WithMany(p => p.BuisnessProcesses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BuisnessP__CodeI__4CA06362");

            entity.HasOne(d => d.Owner).WithMany(p => p.BuisnessProcesses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BuisnessP__Owner__4E88ABD4");

            entity.HasOne(d => d.Process).WithMany(p => p.BuisnessProcesses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BuisnessP__Proce__4D94879B");
        });

        modelBuilder.Entity<CodeProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CodeProc__3214EC27A338E063");
        });

        modelBuilder.Entity<OwnerProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OwnerPro__3214EC07B1455B46");
        });

        modelBuilder.Entity<Process>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Process__3214EC2712F3046B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
