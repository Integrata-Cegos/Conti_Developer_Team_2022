using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IssueManagement.Impl.Entities
{
    public partial class Issues_RefContext : DbContext
    {
        public Issues_RefContext()
        {
        }

        public Issues_RefContext(DbContextOptions<Issues_RefContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Issue> Issues { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=h2908727.stratoserver.net;Initial Catalog=Issues_Ref;User ID=teilnehmer;Password=teilnehmer123!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
            //optionsBuilder.LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasOne(d => d.AssigneeNavigation)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.Assignee)
                    .HasConstraintName("FK__Issues__assignee__68487DD7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
