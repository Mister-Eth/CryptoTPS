﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CryptoTPS.Data.Database
{
    public partial class CryptoTPSContext : DbContext
    {
        public readonly object LockObj = new object();
        public CryptoTPSContext()
        {
            Database.SetCommandTimeout(TimeSpan.FromSeconds(10));
        }

        public CryptoTPSContext(DbContextOptions<CryptoTPSContext> options)
            : base(options)
        {
            //Database.SetCommandTimeout(TimeSpan.FromSeconds(60));
        }

        public virtual DbSet<AccesStat> AccesStats { get; set; }
        public virtual DbSet<CachedResponse> CachedResponses { get; set; }
        public virtual DbSet<Network> Networks { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<ProviderType> ProviderTypes { get; set; }
        public virtual DbSet<TpsDataDay> TpsDataDays { get; set; }
        public virtual DbSet<TpsDataHour> TpsDataHours { get; set; }
        public virtual DbSet<TpsDataMax> TpsDataMaxes { get; set; }
        public virtual DbSet<TpsDataMonth> TpsDataMonths { get; set; }
        public virtual DbSet<TpsDataWeek> TpsDataWeeks { get; set; }
        public virtual DbSet<TpsDataLatest> TpsDataLatests { get; set; }
        public virtual DbSet<OldestLoggedHistoricalEntry> OldestLoggedHistoricalEntries { get; set; }
        public virtual DbSet<TpsDataYear> TpsDataYears { get; set; }
        public virtual DbSet<TpsDataAll> TpsDataAlls { get; set; }
        public virtual DbSet<TimeWarpDataDay> TimeWarpDataDays { get; set; }
        public virtual DbSet<TimeWarpDataHour> TimeWarpDataHours { get; set; }
        public virtual DbSet<TimeWarpDataMinute> TimeWarpDataMinutes { get; set; }
        public virtual DbSet<TimeWarpDataWeek> TimeWarpDataWeeks { get; set; }
       public virtual DbSet<TimeWarpDatum> TimeWarpData { get; set; }
        public virtual DbSet<OldestLoggedTimeWarpBlock> OldestLoggedTimeWarpBlocks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            
            modelBuilder.Entity<TimeWarpDataDay>(entity =>
            {
                entity.ToTable("TimeWarpData_Day");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.TimeWarpDataDays)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Netwo__31B762FC");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TimeWarpDataDays)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Provi__30C33EC3");
            });

            modelBuilder.Entity<TimeWarpDataHour>(entity =>
            {
                entity.ToTable("TimeWarpData_Hour");

                entity.Property(e => e.Id).HasColumnName("ID");

                

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.TimeWarpDataHours)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Netwo__2FCF1A8A");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TimeWarpDataHours)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Provi__2EDAF651");
            });

            modelBuilder.Entity<TimeWarpDataMinute>(entity =>
            {
                entity.ToTable("TimeWarpData_Minute");

                entity.Property(e => e.Id).HasColumnName("ID");

                

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.TimeWarpDataMinutes)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Netwo__2DE6D218");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TimeWarpDataMinutes)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Provi__2CF2ADDF");
            });

            modelBuilder.Entity<TimeWarpDataWeek>(entity =>
            {
                entity.ToTable("TimeWarpData_Week");

                entity.Property(e => e.Id).HasColumnName("ID");

                

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.TimeWarpDataWeeks)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Netwo__339FAB6E");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TimeWarpDataWeeks)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Provi__32AB8735");
            });

            modelBuilder.Entity<TimeWarpDatum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.TimeWarpData)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Netwo__2BFE89A6");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TimeWarpData)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Provi__2B0A656D");
            });

            
            modelBuilder.Entity<OldestLoggedTimeWarpBlock>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.OldestLoggedTimeWarpBlocks)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OldestLog__Netwo__3587F3E0");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.OldestLoggedTimeWarpBlocks)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OldestLog__Provi__3493CFA7");
            });
            
            modelBuilder.Entity<OldestLoggedHistoricalEntry>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.OldestLoggedHistoricalEntries)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OldestLog__Netwo__02084FDA");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.OldestLoggedHistoricalEntries)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OldestLog__Provi__01142BA1");
            });

            modelBuilder.Entity<TpsDataYear>(entity =>
            {
                entity.ToTable("TPSAndGasData_Year");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.TpsDataYears)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Netwo__7C4F7684");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsDataYears)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Provi__7B5B524B");
            });

            modelBuilder.Entity<TpsDataAll>(entity =>
            {
                entity.ToTable("TPSAndGasData_All");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.TpsDataAlls)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Netwo__7E37BEF6");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsDataAlls)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Provi__7D439ABD");
            });

            modelBuilder.Entity<AccesStat>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Project)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<CachedResponse>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__CachedRe__737584F63DE80A10")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Json)
                    .IsUnicode(false)
                    .HasColumnName("JSON");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Network>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Networks__737584F6D329C49A")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TpsDataLatest>(entity =>
            {
                entity.ToTable("TPSAndGasData_Latest");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tps).HasColumnName("TPS");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.TpsDataLatests)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Netwo__787EE5A0");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsDataLatests)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Provi__778AC167");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Provider__737584F641C5EFF8")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.SubchainOfNavigation)
                    .WithMany(p => p.InverseSubchainOfNavigation)
                    .HasForeignKey(d => d.SubchainOf)
                    .HasConstraintName("FK__Providers__Subch__00200768");
            });

            modelBuilder.Entity<ProviderType>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Provider__737584F6267CCF6F")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('#')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TpsDataDay>(entity =>
            {
                entity.ToTable("TPSAndGasData_Day");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.TpsDataDays)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Netwo__48CFD27E");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsDataDays)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Provi__47DBAE45");
            });

            modelBuilder.Entity<TpsDataHour>(entity =>
            {
                entity.ToTable("TPSAndGasData_Hour");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.TpsDataHours)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Netwo__46E78A0C");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsDataHours)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Provi__45F365D3");
            });

            modelBuilder.Entity<TpsDataMax>(entity =>
            {
                entity.ToTable("TPSAndGasData_Max");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.MaxTps).HasColumnName("MaxTPS");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.TpsDataMaxes)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Netwo__44FF419A");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsDataMaxes)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Provi__440B1D61");
            });

            modelBuilder.Entity<TpsDataMonth>(entity =>
            {
                entity.ToTable("TPSAndGasData_Month");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.TpsDataMonths)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Netwo__4CA06362");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsDataMonths)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Provi__4BAC3F29");
            });

            modelBuilder.Entity<TpsDataWeek>(entity =>
            {
                entity.ToTable("TPSAndGasData_Week");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.NetworkNavigation)
                    .WithMany(p => p.TpsDataWeeks)
                    .HasForeignKey(d => d.Network)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Netwo__4AB81AF0");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsDataWeeks)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSAndGas__Provi__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}