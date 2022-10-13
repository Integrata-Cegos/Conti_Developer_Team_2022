using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IssueManagement.Impl.Entities
{
    public partial class Issue
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("description")]
        [StringLength(256)]
        [Unicode(false)]
        public string? Description { get; set; }
        [Column("status")]
        public byte? Status { get; set; }
        [Column("priority")]
        public byte? Priority { get; set; }
        [Column("assignee")]
        public int? Assignee { get; set; }

        [ForeignKey("Assignee")]
        [InverseProperty("Issues")]
        public virtual User? AssigneeNavigation { get; set; }
    }
}
