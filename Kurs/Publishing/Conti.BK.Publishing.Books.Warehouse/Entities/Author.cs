using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Conti.BK.Publishing.Books.Warehouse.Entities
{
    [Table("AUTHORS")]
    public partial class Author
    {
        public Author()
        {
            Isbns = new HashSet<Book>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("LASTNAME")]
        [StringLength(50)]
        [Unicode(false)]
        public string Lastname { get; set; } = null!;
        [Column("FIRSTNAME")]
        [StringLength(50)]
        [Unicode(false)]
        public string Firstname { get; set; } = null!;

        [ForeignKey("AuthorId")]
        [InverseProperty("Authors")]
        public virtual ICollection<Book> Isbns { get; set; }
    }
}
