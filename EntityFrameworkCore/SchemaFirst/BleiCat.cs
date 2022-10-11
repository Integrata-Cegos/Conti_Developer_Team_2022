namespace SchemaFirst.Annotations.Entities;

public partial class Bleicat
{
    public Bleicat(){}

    public Bleicat (string name, double weight, string coatColor)
    {
        this.Name = name;
        this.Weight = weight;
        this.Coatcolor = coatColor;
    }

    public override string ToString()
    {
        return $"Cat: id={this.Id}, name={this.Name}, coatColor={this.Coatcolor}, weight={this.Weight}";
    }

    public void Annoy()
    {
        Console.WriteLine("miau");
    }
}