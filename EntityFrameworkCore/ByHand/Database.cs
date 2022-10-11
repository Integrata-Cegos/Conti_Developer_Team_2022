using Microsoft.EntityFrameworkCore;

namespace Javacream.Efc{

    public class LS_Cat{
        public virtual string Name {get; set;}
        public virtual double Weight {get; set;}
        public virtual string CoatColor {get; set;}

        public LS_Cat(string name, double weight, string coatColor)
        {
            this.Name = name;
            this.CoatColor = coatColor;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return $"Cat: id={this.Id}, name={this.Name}, coatColor={this.CoatColor}, weight={this.Weight}";
        }

        public void Annoy()
        {
            Console.WriteLine("maunz maunz");
        }
        // Entity-Spezifikation, Deklaration der Attribute als virtual erlaubt ein Überschreiben durch den DbContext 
        public virtual int Id {get; set;}
        public LS_Cat(){}
    }

        public class LS_CatContext: DbContext
        {
            public virtual DbSet<LS_Cat> LS_Cats { get; set; } = null!;
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("Data Source=h2908727.stratoserver.net;Initial Catalog=publishing;User ID=teilnehmer;password=teilnehmer123!");
                }
            }

    }

}