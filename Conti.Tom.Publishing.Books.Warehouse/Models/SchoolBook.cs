using Conti.Tom.Publishing.Books.IsbnGenerator.Models;

namespace Conti.Tom.Publishing.Books.Warehouse.Models
{
    public class SchoolBook : Book
    {
        public string Subject { get; }
        public int Year { get; }

        public SchoolBook(ISBN isbn, string title, int pages, double price, bool available, int year, string subject ) : base(isbn, title, pages, price, available)
        {
            Subject = subject;
            Year = year;
        }
        public override string Info()
        {
            return $"ISBN:{ISBN} / Title:{Title} / Pages:{Pages} / Price:{Price}Euro / Available:{Available} / Subject:{Subject} / Year:{Year}";
        }
    }
}
