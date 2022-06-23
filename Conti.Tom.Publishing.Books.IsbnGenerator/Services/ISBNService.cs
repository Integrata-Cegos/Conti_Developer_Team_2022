namespace Conti.Tom.Publishing.Books.IsbnGenerator
{
    public class ISBNService : IISBNService
    {
        private static int _ISBNCounter = 1;

        public ISBN Next()
        {
            return new(1, 2, 3, _ISBNCounter++);
        }
    }
}
