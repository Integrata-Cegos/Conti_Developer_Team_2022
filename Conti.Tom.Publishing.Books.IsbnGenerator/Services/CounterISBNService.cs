using Conti.Tom.Publishing.Books.IsbnGenerator.Models;

namespace Conti.Tom.Publishing.Books.IsbnGenerator.Services
{
    public class CounterIsbnService : BaseISBNService
    {
        private static int _counter = 1;

        public override ISBN Next()
        {
            return new ISBN(Prefix, CountryCode, 1, 2, 4, _counter++);

        }
    }
}
