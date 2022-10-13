using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Conti.BK.IssueManagement.Impl.Entities
{
    [Table("BK_Issues")]
    public partial class BkIssue
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
        [InverseProperty("BkIssues")]
        public virtual BkUser? AssigneeNavigation { get; set; }
    }
}
