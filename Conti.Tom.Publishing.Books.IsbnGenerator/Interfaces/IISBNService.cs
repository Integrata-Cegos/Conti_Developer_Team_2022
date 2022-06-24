using Conti.Tom.Publishing.Books.IsbnGenerator.Models;

namespace Conti.Tom.Publishing.Books.IsbnGenerator.Interfaces
{
    public interface IISBNService
    {
        ISBN Next();
        public string Prefix { get; set; } 
        public string CountryCode { get; set; }
    }
}