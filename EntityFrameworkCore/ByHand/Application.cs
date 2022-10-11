using Microsoft.EntityFrameworkCore;

namespace Conti.AB.Efc;

public class BleiCat
{
    public virtual string Name {get; set;}
    public virtual double Weight {get; set;}
    public virtual string CoatColor {get; set;}

    public BleiCat (string name, double weight, string coatColor)
    {
        this.Name = name;
        this.Weight = weight;
        this.CoatColor = coatColor;
    }

    public override string ToString()
    {
        return $"Cat: id={this.Id}, name={this.Name}, coatColor={this.CoatColor}, weight={this.Weight}";
    }

    public void Annoy()
    {
        Console.WriteLine("miau");
    }

    public virtual int Id {get; set;}
    public BleiCat(){}

}

    public class BleiCatContext : DbContext
    {
        public virtual DbSet<BleiCat> BleiCats {get; set;} = null;
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=h2908727.stratoserver.net;Initial Catalog=publishing;User ID=teilnehmer;password=teilnehmer123!");
            }
        }

    }