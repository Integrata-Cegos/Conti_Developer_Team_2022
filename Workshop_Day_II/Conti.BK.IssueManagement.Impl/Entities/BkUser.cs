using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Conti.BK.IssueManagement.Impl.Entities
{
    [Table("BK_Users")]
    [Index("Username", Name = "UQ__BK_Users__F3DBC5725A52D2D6", IsUnique = true)]
    public partial class BkUser
    {
        public BkUser()
        {
            BkIssues = new HashSet<BkIssue>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("username")]
        [StringLength(64)]
        [Unicode(false)]
        public string Username { get; set; } = null!;
        [Column("lastname")]
        [StringLength(64)]
        [Unicode(false)]
        public string Lastname { get; set; } = null!;
        [Column("firstname")]
        [StringLength(64)]
        [Unicode(false)]
        public string Firstname { get; set; } = null!;

        [InverseProperty("AssigneeNavigation")]
        public virtual ICollection<BkIssue> BkIssues { get; set; }
    }
}
