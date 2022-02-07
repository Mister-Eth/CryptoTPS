using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CryptoTPS.Data.Temp
{
    public partial class CryptoTPSDevContext : DbContext
    {
        public CryptoTPSDevContext()
        {
        }

        public CryptoTPSDevContext(DbContextOptions<CryptoTPSDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccesStat> AccesStats { get; set; }
        public virtual DbSet<AggregatedCounter> AggregatedCounters { get; set; }
        public virtual DbSet<Apikey> Apikeys { get; set; }
        public virtual DbSet<Counter> Counters { get; set; }
        public virtual DbSet<DetailedAccessStat> DetailedAccessStats { get; set; }
        public virtual DbSet<Hash> Hashes { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobParameter> JobParameters { get; set; }
        public virtual DbSet<JobQueue> JobQueues { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<OldestLoggedHistoricalEntry> OldestLoggedHistoricalEntries { get; set; }
        public virtual DbSet<OldestLoggedTimeWarpBlock> OldestLoggedTimeWarpBlocks { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Schema> Schemas { get; set; }
        public virtual DbSet<Server> Servers { get; set; }
        public virtual DbSet<Set> Sets { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<TimeWarpDataDay> TimeWarpDataDays { get; set; }
        public virtual DbSet<TimeWarpDataHour> TimeWarpDataHours { get; set; }
        public virtual DbSet<TimeWarpDataMinute> TimeWarpDataMinutes { get; set; }
        public virtual DbSet<TimeWarpDataWeek> TimeWarpDataWeeks { get; set; }
        public virtual DbSet<TimeWarpDatum> TimeWarpData { get; set; }
        public virtual DbSet<TpsdataAll> TpsdataAlls { get; set; }
        public virtual DbSet<TpsdataDay> TpsdataDays { get; set; }
        public virtual DbSet<TpsdataHour> TpsdataHours { get; set; }
        public virtual DbSet<TpsdataLatest> TpsdataLatests { get; set; }
        public virtual DbSet<TpsdataMax> TpsdataMaxes { get; set; }
        public virtual DbSet<TpsdataMonth> TpsdataMonths { get; set; }
        public virtual DbSet<TpsdataWeek> TpsdataWeeks { get; set; }
        public virtual DbSet<TpsdataYear> TpsdataYears { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

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

            modelBuilder.Entity<AggregatedCounter>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_HangFire_CounterAggregated");

                entity.ToTable("AggregatedCounter", "HangFire");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_AggregatedCounter_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Apikey>(entity =>
            {
                entity.ToTable("APIKeys");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KeyHash)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Id })
                    .HasName("PK_HangFire_Counter");

                entity.ToTable("Counter", "HangFire");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<DetailedAccessStat>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Hash>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Field })
                    .HasName("PK_HangFire_Hash");

                entity.ToTable("Hash", "HangFire");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Hash_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Field).HasMaxLength(100);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job", "HangFire");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Job_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.HasIndex(e => e.StateName, "IX_HangFire_Job_StateName")
                    .HasFilter("([StateName] IS NOT NULL)");

                entity.Property(e => e.Arguments).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.InvocationData).IsRequired();

                entity.Property(e => e.StateName).HasMaxLength(20);
            });

            modelBuilder.Entity<JobParameter>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Name })
                    .HasName("PK_HangFire_JobParameter");

                entity.ToTable("JobParameter", "HangFire");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobParameters)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_JobParameter_Job");
            });

            modelBuilder.Entity<JobQueue>(entity =>
            {
                entity.HasKey(e => new { e.Queue, e.Id })
                    .HasName("PK_HangFire_JobQueue");

                entity.ToTable("JobQueue", "HangFire");

                entity.Property(e => e.Queue).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FetchedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Id })
                    .HasName("PK_HangFire_List");

                entity.ToTable("List", "HangFire");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_List_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<OldestLoggedHistoricalEntry>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.OldestLoggedHistoricalEntries)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OldestLog__Provi__5165187F");
            });

            modelBuilder.Entity<OldestLoggedTimeWarpBlock>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.OldestLoggedTimeWarpBlocks)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OldestLog__Provi__571DF1D5");
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
            });

            modelBuilder.Entity<Schema>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PK_HangFire_Schema");

                entity.ToTable("Schema", "HangFire");

                entity.Property(e => e.Version).ValueGeneratedNever();
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.ToTable("Server", "HangFire");

                entity.HasIndex(e => e.LastHeartbeat, "IX_HangFire_Server_LastHeartbeat");

                entity.Property(e => e.Id).HasMaxLength(200);

                entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Value })
                    .HasName("PK_HangFire_Set");

                entity.ToTable("Set", "HangFire");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Set_ExpireAt")
                    .HasFilter("([ExpireAt] IS NOT NULL)");

                entity.HasIndex(e => new { e.Key, e.Score }, "IX_HangFire_Set_Score");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(256);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Id })
                    .HasName("PK_HangFire_State");

                entity.ToTable("State", "HangFire");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_State_Job");
            });

            modelBuilder.Entity<TimeWarpDataDay>(entity =>
            {
                entity.ToTable("TimeWarpData_Day");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TimeWarpDataDays)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Provi__5535A963");
            });

            modelBuilder.Entity<TimeWarpDataHour>(entity =>
            {
                entity.ToTable("TimeWarpData_Hour");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TimeWarpDataHours)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Provi__5441852A");
            });

            modelBuilder.Entity<TimeWarpDataMinute>(entity =>
            {
                entity.ToTable("TimeWarpData_Minute");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TimeWarpDataMinutes)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Provi__534D60F1");
            });

            modelBuilder.Entity<TimeWarpDataWeek>(entity =>
            {
                entity.ToTable("TimeWarpData_Week");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TimeWarpDataWeeks)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Provi__5629CD9C");
            });

            modelBuilder.Entity<TimeWarpDatum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TimeWarpData)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TimeWarpD__Provi__52593CB8");
            });

            modelBuilder.Entity<TpsdataAll>(entity =>
            {
                entity.ToTable("TPSData_All");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsdataAlls)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSData_A__Provi__5070F446");
            });

            modelBuilder.Entity<TpsdataDay>(entity =>
            {
                entity.ToTable("TPSData_Day");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.OclhJson)
                    .HasMaxLength(255)
                    .HasColumnName("OCLH_JSON");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsdataDays)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSData_D__Provi__4CA06362");
            });

            modelBuilder.Entity<TpsdataHour>(entity =>
            {
                entity.ToTable("TPSData_Hour");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.OclhJson)
                    .HasMaxLength(255)
                    .HasColumnName("OCLH_JSON");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsdataHours)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSData_H__Provi__4BAC3F29");
            });

            modelBuilder.Entity<TpsdataLatest>(entity =>
            {
                entity.ToTable("TPSData_Latest");

                entity.HasIndex(e => e.Provider, "UQ__TPSData___9944610B3A248916")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Tps).HasColumnName("TPS");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithOne(p => p.TpsdataLatest)
                    .HasForeignKey<TpsdataLatest>(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSData_L__Provi__49C3F6B7");
            });

            modelBuilder.Entity<TpsdataMax>(entity =>
            {
                entity.ToTable("TPSData_Max");

                entity.HasIndex(e => e.Provider, "UQ__TPSData___9944610BABF8C74B")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.MaxTps).HasColumnName("MaxTPS");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithOne(p => p.TpsdataMax)
                    .HasForeignKey<TpsdataMax>(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSData_M__Provi__4AB81AF0");
            });

            modelBuilder.Entity<TpsdataMonth>(entity =>
            {
                entity.ToTable("TPSData_Month");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsdataMonths)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSData_M__Provi__4E88ABD4");
            });

            modelBuilder.Entity<TpsdataWeek>(entity =>
            {
                entity.ToTable("TPSData_Week");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.OclhJson)
                    .HasMaxLength(255)
                    .HasColumnName("OCLH_JSON");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsdataWeeks)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSData_W__Provi__4D94879B");
            });

            modelBuilder.Entity<TpsdataYear>(entity =>
            {
                entity.ToTable("TPSData_Year");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AverageTps).HasColumnName("AverageTPS");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProviderNavigation)
                    .WithMany(p => p.TpsdataYears)
                    .HasForeignKey(d => d.Provider)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TPSData_Y__Provi__4F7CD00D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
