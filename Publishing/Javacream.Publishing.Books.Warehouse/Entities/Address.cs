using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Javacream.Publishing.Books.Warehouse.Entities
{
    [Table("ADDRESSES")]
    public partial class Address
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CITY")]
        [StringLength(50)]
        [Unicode(false)]
        public string? City { get; set; }
        [Column("STREET")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Street { get; set; }
    }
}
