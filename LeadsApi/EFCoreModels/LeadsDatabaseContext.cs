using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LeadsApi.EFCoreModels
{
    public partial class LeadsDatabaseContext : DbContext
    {
        public LeadsDatabaseContext()
        {
        }

        public LeadsDatabaseContext(DbContextOptions<LeadsDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lead> Leads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Name=ConnectionStrings:LeadsDatabaseContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lead>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Lead");

                entity.Property(e => e.Id).HasColumnType("Integer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
