// <copyright file="NBAdbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBA.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    /// <summary>
    /// The descendant class from the DbContext resposible to create and fill the database with content.
    /// </summary>
    public partial class NBAdbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBAdbContext"/> class.
        /// </summary>
        public NBAdbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NBAdbContext"/> class.
        /// </summary>
        /// <param name="options">ensures that the Db is indeed creted(?).</param>
        public NBAdbContext(DbContextOptions<NBAdbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or Sets the Coach DbSet.
        /// </summary>
        public virtual DbSet<Coach> Coach { get; set; }

        /// <summary>
        /// Gets or Sets the Connector table between the coach and the taem DbSet.
        /// </summary>
        public virtual DbSet<ConnCoachTeam> ConnCoachTeam { get; set; }

        /// <summary>
        /// Gets or Sets the Player DbSet.
        /// </summary>
        public virtual DbSet<Player> Player { get; set; }

        /// <summary>
        /// Gets or Sets the Team DbSet.
        /// </summary>
        public virtual DbSet<Team> Team { get; set; }

        /// <summary>
        /// Overriden method resposiblle for stablishing the connection with the database.
        /// -The proxies allow the lazy loading.
        /// -The tools allow us to Drop-Database, Get - DbContext.
        /// -The sql server allows us to use the sql server.
        /// </summary>
        /// <param name="optionsBuilder">Responsilble to check and set the connection if there isnt one already.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null && !optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().
                    UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\NBAdb.mdf; Integrated Security=True; MultipleActiveResultSets = True");
            }
        }

        /// <summary>
        /// Overriden  method responsible for setting up the table itself.
        /// </summary>
        /// <param name="modelBuilder">Responsible to build the tables using fluent API.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                modelBuilder.Entity<Coach>(entity =>
                {
                    entity.ToTable("coach");

                    entity.Property(e => e.CoachId)
                        .HasColumnName("coach_id")
                        .ValueGeneratedNever();

                    entity.Property(e => e.CoachAge).HasColumnName("coach_age");

                    entity.Property(e => e.CoachEmail)
                        .HasColumnName("coach_email")
                        .HasMaxLength(100);

                    entity.Property(e => e.CoachHireDate)
                        .HasColumnName("coach_hireDate")
                        .HasColumnType("date");

                    entity.Property(e => e.CoachName)
                        .HasColumnName("coach_name")
                        .HasMaxLength(100);

                    entity.Property(e => e.CoachSalary).HasColumnName("coach_salary");

                    entity.Property(e => e.CoachType)
                        .HasColumnName("coach_type")
                        .HasMaxLength(100);

                    entity.Property(e => e.CoachYearsOfExperience).HasColumnName("coach_yearsOfExperience");
                });

                modelBuilder.Entity<ConnCoachTeam>(entity =>
                {
                    entity.HasKey(e => e.ConnId)
                        .HasName("PK__conn_coa__9FC140B61FA58F4B");

                    entity.ToTable("conn_coach_team");

                    entity.Property(e => e.ConnId).HasColumnName("conn_id");

                    entity.Property(e => e.ConnCoach).HasColumnName("conn_coach");

                    entity.Property(e => e.ConnTeam).HasColumnName("conn_team");

                    entity.HasOne(d => d.ConnCoachNavigation)
                        .WithMany(p => p.ConnCoachTeam)
                        .HasForeignKey(d => d.ConnCoach)
                        .HasConstraintName("FK__conn_coac__conn___3F466844");

                    entity.HasOne(d => d.ConnTeamNavigation)
                        .WithMany(p => p.ConnCoachTeam)
                        .HasForeignKey(d => d.ConnTeam)
                        .HasConstraintName("FK__conn_coac__conn___403A8C7D");
                });

                modelBuilder.Entity<Player>(entity =>
                {
                    entity.ToTable("player");

                    entity.Property(e => e.PlayerId)
                        .HasColumnName("player_id")
                        .ValueGeneratedNever();

                    entity.Property(e => e.PlayerAge).HasColumnName("player_age");

                    entity.Property(e => e.PlayerDraftDate)
                        .HasColumnName("player_draftDate")
                        .HasColumnType("date");

                    entity.Property(e => e.PlayerFieldGoal).HasColumnName("player_fieldGoal");

                    entity.Property(e => e.PlayerHeight).HasColumnName("player_height");

                    entity.Property(e => e.PlayerName)
                        .HasColumnName("player_name")
                        .HasMaxLength(100);

                    entity.Property(e => e.PlayerPosition)
                        .HasColumnName("player_position")
                        .HasMaxLength(100);

                    entity.Property(e => e.PlayerSalary).HasColumnName("player_salary");

                    entity.Property(e => e.PlayerTeam).HasColumnName("player_team");

                    entity.Property(e => e.PlayerWeight).HasColumnName("player_weight");

                    entity.HasOne(d => d.PlayerTeamNavigation)
                        .WithMany(p => p.Player)
                        .HasForeignKey(d => d.PlayerTeam)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__player__player_t__3A81B327");
                });

                modelBuilder.Entity<Team>(entity =>
                {
                    entity.ToTable("team");

                    entity.Property(e => e.TeamId)
                        .HasColumnName("team_id")
                        .ValueGeneratedNever();

                    entity.Property(e => e.TeamArena)
                        .HasColumnName("team_arena")
                        .HasMaxLength(100);

                    entity.Property(e => e.TeamChampionshipsWon).HasColumnName("team_championshipsWon");

                    entity.Property(e => e.TeamConference)
                        .HasColumnName("team_conference")
                        .HasMaxLength(100);

                    entity.Property(e => e.TeamFoundationDate)
                        .HasColumnName("team_foundationDate")
                        .HasColumnType("date");

                    entity.Property(e => e.TeamName)
                        .HasColumnName("team_name")
                        .HasMaxLength(100);
                });

                this.OnModelCreatingPartial(modelBuilder);
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
