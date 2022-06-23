using Conti.Tom.Publishing.Books.IsbnGenerator;

namespace Conti.Tom.Publishing.Books.Warehouse.Models
{
    public class SpecialistBook : Book
    {
        public string Topic { get; }

        public SpecialistBook(ISBN isbn, string title, int pages, double price, bool available, string topic) : base(isbn, title, pages, price, available)
        {
            Topic = topic;
        }

        public override string Info()
        {
            return $"ISBN:{ISBN} / Title:{Title} / Pages:{Pages} / Price:{Price}Euro / Available:{Available} / Topic:{Topic}";
        }
    }
}
