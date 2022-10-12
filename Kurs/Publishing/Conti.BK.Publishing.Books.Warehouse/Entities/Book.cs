using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Conti.BK.Publishing.Books.Warehouse.Entities
{
    [Table("BOOKS")]
    [Index("Price", Name = "BOOKS_PRICE")]
    [Index("Title", Name = "BOOKS_TITLE")]
    [Index("Isbn", Name = "UQ__BOOKS__447D36EA4C2C7644", IsUnique = true)]
    [Index("Title", Name = "UQ__BOOKS__475DFD2FE9CFA860", IsUnique = true)]
    public partial class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        [Key]
        [Column("ISBN")]
        [StringLength(20)]
        [Unicode(false)]
        public string Isbn { get; set; } = null!;
        [Column("TITLE")]
        [StringLength(100)]
        [Unicode(false)]
        public string Title { get; set; } = null!;
        [Column("PAGES")]
        public int? Pages { get; set; }
        [Column("PRICE")]
        public double? Price { get; set; }
        [Column("AVAILABLE")]
        public bool Available { get; set; }
        [Column("PUBLISHER_ID")]
        public int? PublisherId { get; set; }
        [Column("SUBJECT")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Subject { get; set; }
        [Column("YEAR")]
        public int? Year { get; set; }
        [Column("TOPIC")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Topic { get; set; }
        [Column("DISCRIMINATOR")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Discriminator { get; set; }

        [ForeignKey("PublisherId")]
        [InverseProperty("Books")]
        public virtual Publisher? Publisher { get; set; }

        [ForeignKey("Isbn")]
        [InverseProperty("Isbns")]
        public virtual ICollection<Author> Authors { get; set; }
    }
}
