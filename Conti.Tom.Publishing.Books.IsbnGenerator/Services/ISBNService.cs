using Conti.Tom.Publishing.Books.IsbnGenerator.Interfaces;
using Conti.Tom.Publishing.Books.IsbnGenerator.Models;

namespace Conti.Tom.Publishing.Books.IsbnGenerator.Services
{
    public class ISBNService : IISBNService
    {
        private static int _ISBNCounter = 1;

        public string Prefix { get; set; }
        public string CountryCode { get; set; }

        public ISBN Next()
        {
            return new(1, 2, 3, _ISBNCounter++);
        }
    }
}
