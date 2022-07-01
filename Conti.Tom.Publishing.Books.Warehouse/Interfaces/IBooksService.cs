using Conti.Tom.Publishing.Books.IsbnGenerator;
using Conti.Tom.Publishing.Books.IsbnGenerator.Models;
using Conti.Tom.Publishing.Books.Warehouse.Models;

namespace Conti.Tom.Publishing.Books.Warehouse.Interfaces;

public interface IBooksService
{
    ISBN CreateBook(string title, int pages, double price, Dictionary<string, object> options);
    void DeleteBookByIsbn(ISBN isbn);
    Book FindBookByIsbn(ISBN isbn);
    List<Book> FindBooksByPriceRange(double min, double max);
    List<Book> FindBooksByTitle(string title);
    void UpdateBook(Book book);
}