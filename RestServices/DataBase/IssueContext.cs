using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBase;
public partial class IssueContext : DbContext
{
	public IssueContext(DbContextOptions<IssueContext> options) : base(options) { }

    public virtual DbSet<Issue> Issues { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
