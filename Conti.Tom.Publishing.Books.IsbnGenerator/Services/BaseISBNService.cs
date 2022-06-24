using Conti.Tom.Publishing.Books.IsbnGenerator.Interfaces;
using Conti.Tom.Publishing.Books.IsbnGenerator.Models;

namespace Conti.Tom.Publishing.Books.IsbnGenerator.Services
{
    public abstract class BaseISBNService : IISBNService
    {
        public abstract ISBN Next();
        public string Prefix { get; set; } = "ISBN:";
        public string CountryCode { get; set; } = "-de";
    }
}
