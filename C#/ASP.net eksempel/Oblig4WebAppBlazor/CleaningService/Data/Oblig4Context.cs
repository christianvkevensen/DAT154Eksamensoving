using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CleaningService.Models
{
    public partial class Oblig4Context : DbContext
    {
        public Oblig4Context()
        {
        }

        public Oblig4Context(DbContextOptions<Oblig4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<Oppgave> Oppgaver { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservations");

                entity.HasIndex(e => e.RoomNumber, "IX_reservations_RoomNumber");

                entity.HasIndex(e => e.UserName, "IX_reservations_UserName");

                entity.Property(e => e.EndDate).HasColumnName("endDate");

                entity.Property(e => e.StartDate).HasColumnName("startDate");

                entity.HasOne(d => d.RoomNumberNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.RoomNumber);

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.UserName);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.RoomNumber);

                entity.ToTable("rooms");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.ToTable("users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
