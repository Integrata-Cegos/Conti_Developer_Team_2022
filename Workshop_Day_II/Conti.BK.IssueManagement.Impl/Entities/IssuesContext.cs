﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Conti.BK.IssueManagement.Impl.Entities
{
    public partial class IssuesContext : DbContext
    {
        public IssuesContext()
        {
        }

        public IssuesContext(DbContextOptions<IssuesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BkIssue> BkIssues { get; set; } = null!;
        public virtual DbSet<BkUser> BkUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=h2908727.stratoserver.net;Initial Catalog=Issues;User ID=teilnehmer;Password=teilnehmer123!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BkIssue>(entity =>
            {
                entity.HasOne(d => d.AssigneeNavigation)
                    .WithMany(p => p.BkIssues)
                    .HasForeignKey(d => d.Assignee)
                    .HasConstraintName("FK__BK_Issues__assig__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
