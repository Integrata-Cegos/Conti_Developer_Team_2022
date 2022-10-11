namespace SchemaFirst.Annotations.Entities
{

    public partial class LS_Cat
    {
        public LS_Cat(){}
        public LS_Cat(string name, double weight, string coatColor)
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