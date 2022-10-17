using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Database.Models;

[Table("USERS")]
[Index("Username", Name = "UQ__USERS__B15BE12E67CF2CA7", IsUnique = true)]
public partial class User
{
    public User()
    {
        Issues = new HashSet<Issue>();
    }

    [Key]
    [Column("ID")]
    public int Id { get; set; }
    [Column("USERNAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string Username { get; set; } = null!;
    [Column("FIRSTNAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string Firstname { get; set; } = null!;
    [Column("LASTNAME")]
    [StringLength(50)]
    [Unicode(false)]
    public string Lastname { get; set; } = null!;

    [InverseProperty("AssigneeNavigation")]
    public virtual ICollection<Issue> Issues { get; set; }
}
