using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IssueManagement.Impl.Entities
{
    [Index("Username", Name = "UQ__Users__F3DBC5721A41CC83", IsUnique = true)]
    public partial class User
    {
        public User()
        {
            Issues = new HashSet<Issue>();
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
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
