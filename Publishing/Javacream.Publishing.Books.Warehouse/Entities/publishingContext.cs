using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Javacream.Publishing.Books.Warehouse.Entities
{
    public partial class publishingContext : DbContext
    {
        public publishingContext()
        {
        }

        public publishingContext(DbContextOptions<publishingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Publisher> Publishers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=h2908727.stratoserver.net;Initial Catalog=publishing;User ID=teilnehmer;Password=teilnehmer123!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Isbn)
                    .HasName("PK__BOOKS__447D36EB0CB40285");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK__BOOKS__PUBLISHER__2A4B4B5E");

                entity.HasMany(d => d.Authors)
                    .WithMany(p => p.Isbns)
                    .UsingEntity<Dictionary<string, object>>(
                        "BooksAuthor",
                        l => l.HasOne<Author>().WithMany().HasForeignKey("AuthorId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__BOOKS_AUT__AUTHO__34C8D9D1"),
                        r => r.HasOne<Book>().WithMany().HasForeignKey("Isbn").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__BOOKS_AUTH__ISBN__33D4B598"),
                        j =>
                        {
                            j.HasKey("Isbn", "AuthorId").HasName("PK__BOOKS_AU__0EFEAEFF5B82786C");

                            j.ToTable("BOOKS_AUTHORS");

                            j.IndexerProperty<string>("Isbn").HasMaxLength(20).IsUnicode(false).HasColumnName("ISBN");

                            j.IndexerProperty<int>("AuthorId").HasColumnName("AUTHOR_ID");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
