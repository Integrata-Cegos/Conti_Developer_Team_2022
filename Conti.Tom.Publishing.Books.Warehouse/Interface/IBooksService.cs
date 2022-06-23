using Conti.Tom.Publishing.Books.IsbnGenerator;
using Conti.Tom.Publishing.Books.Warehouse.Models;

namespace Conti.Tom.Publishing.Books.Warehouse
{
    public interface IBooksService
    {
        Book CreateBook(string title, int pages, double price, Dictionary<string, object> options);
        void DeleteBookByIsbn(ISBN isbn);
        Book FindBookByIsbn(ISBN isbn);
        List<Book> FindBooksByPriceRange(double min, double max);
        List<Book> FindBooksByTitle(string title);
    }
}