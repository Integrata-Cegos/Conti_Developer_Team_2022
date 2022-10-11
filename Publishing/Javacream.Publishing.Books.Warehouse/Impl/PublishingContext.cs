using Microsoft.EntityFrameworkCore;
using Javacream.Books.API;
namespace Javacream.Books.Impl{
    public partial class PublishingContext : DbContext
    {
        public PublishingContext()
        {
        }

        public PublishingContext(DbContextOptions<PublishingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Publisher> Publishers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=h2908727.stratoserver.net;Initial Catalog=publishing;User ID=teilnehmer;password=teilnehmer123!");
            }
        }
    }
}
