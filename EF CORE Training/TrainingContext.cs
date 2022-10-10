using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_Training;
public class TrainingContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Adress> Adresses { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("data source=qrbg.conti.de; initial catalog=training;persist security info=True; Integrated Security=SSPI; Database=training");
}


public class Book
{
    [Key]
    public int ISBN { get; set; }
    public string Title { get; set; }
    [Range (0, int.MaxValue)]
    public int Pages { get; set; }
    [Range(0, float.MaxValue)]
    public float Price { get; set; }
    public bool Available { get; set; }
    public Publisher? BookPublisher { get; set; }
    public Author? BookAuthor { get; set; }
}

public class Adress
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
}

public class Author
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public Adress? AuthorAdress { get; set; }
}

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Adress? PublisherAdress { get; set; }
}
