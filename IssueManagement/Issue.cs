using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IssueManagement
{
    [Table("ISSUES")]
    public partial class Issue
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ASSIGNEE")]
        public int? Assignee { get; set; }
        [Column("DESCRIPTION")]
        [StringLength(500)]
        [Unicode(false)]
        public string Description { get; set; } = null!;
        [Column("STATUS")]
        [StringLength(50)]
        [Unicode(false)]
        public string Status { get; set; } = null!;
        [Column("PRIORITY")]
        [StringLength(50)]
        [Unicode(false)]
        public string Priority { get; set; } = null!;

        [ForeignKey("Assignee")]
        [InverseProperty("Issues")]
        public virtual User? AssigneeNavigation { get; set; }
    }
}
