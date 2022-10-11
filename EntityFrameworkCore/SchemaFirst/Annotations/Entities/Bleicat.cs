using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchemaFirst.Annotations.Entities
{
    [Table("BLEICATS")]
    public partial class Bleicat
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column("coatcolor")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Coatcolor { get; set; }
        [Column("weight")]
        public double? Weight { get; set; }
    }
}
