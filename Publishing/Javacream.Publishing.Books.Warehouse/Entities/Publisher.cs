using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Javacream.Publishing.Books.Warehouse.Entities
{
    [Table("PUBLISHERS")]
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("NAME")]
        [StringLength(50)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [InverseProperty("Publisher")]
        public virtual ICollection<Book> Books { get; set; }
    }
}
