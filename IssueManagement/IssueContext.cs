using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IssueManagement
{
    public partial class IssueContext : DbContext
    {
        public IssueContext()
        {
        }

        public IssueContext(DbContextOptions<IssueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<Issue> Issues { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source = qrbg.conti.de; initial catalog = training; persist security info=True; Integrated Security = SSPI; Database=c1tt");
                optionsBuilder.LogTo(Console.WriteLine);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>(entity =>
            {
                entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IssueNavigation)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.Issue)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HISTORY__ISSUE__7E42ABEE");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasOne(d => d.AssigneeNavigation)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.Assignee)
                    .HasConstraintName("FK__ISSUES__ASSIGNEE__69478F08");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
