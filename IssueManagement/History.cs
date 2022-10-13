using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IssueManagement
{
    [Table("HISTORY")]
    public partial class History
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("TIMESTAMP", TypeName = "datetime")]
        public DateTime? Timestamp { get; set; }
        [Column("OPERATION")]
        [Unicode(false)]
        public string? Operation { get; set; }
        [Column("ISSUE")]
        public int Issue { get; set; }
        [Column("DATA")]
        [Unicode(false)]
        public string? Data { get; set; }

        [ForeignKey("Issue")]
        [InverseProperty("Histories")]
        public virtual Issue IssueNavigation { get; set; } = null!;
    }
}
