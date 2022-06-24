using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conti.Tom.Publishing.Books.Warehouse.Test;

internal class BooksServiceIntegrationTests
{
    private static IBooksService _booksService;
    public static IBooksService BooksService { get { return _booksService; } }


    static BooksServiceIntegrationTests()
    {
        var randomIsbnService = new RandomISBNService();
        randomIsbnService.Prefix = "Test-ISBN";
        randomIsbnService.CountryCode = "-dk";
        var storeService = new StoreService();
        storeService.SetStock("books", new ISBN(4, 5, 6, 7), 100);
        storeService.SetStock("books", new ISBN(4, 5, 6, 8), 10);
        var booksService = new BooksService(randomIsbnService, storeService);
        _booksService = booksService;
    }
}

public class CreateBookTests
{
    private IBooksService _booksService;
    [SetUp]
    public void Setup()
    {
        _booksService = BooksServiceUnitTestContext.BooksService;
    }

    [Test]
    public void CreateBooksWithValidParamsGeneratesIsbn()
    {
        Dictionary<string, Object> empty = new Dictionary<string, Object>();
        ISBN generated = _booksService.CreateBook("Title1", 100, 19.99, empty);
        Assert.NotNull(generated);
    }

    [Test]
    public void CreateBooksWithInvalidParamsThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _booksService.CreateBook(null, -1, -1.1, null));
    }
}
