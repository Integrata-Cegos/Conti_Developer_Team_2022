namespace SchemaFirst.Annotations.Entities
{

    public partial class Cat
    {
        public Cat(){}
        public Cat(string name, double weight, string coatColor)
        {
            this.Name = name;
            this.Coatcolor = coatColor;
            this.Weight = weight;
        }

        public void Annoy()
        {
            Console.WriteLine("maunz maunz");
        }
        public override string ToString()
        {
            return $"Cat: id={this.Id}, name={this.Name}, coatColor={this.Coatcolor}, weight={this.Weight}";
        }

    }
}

