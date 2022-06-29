using NUnit.Framework;
using Conti.Guido.Books.API;
using Conti.Guido.Books.Impl;
using Conti.Guido.IsbnGenerator.API;
using Conti.Guido.IsbnGenerator.Impl;
using Conti.Guido.Store.API;
using Conti.Guido.Store.Impl;


namespace Conti.Guido.Publishing.Books.Warehouse.Test;


static class TestContext
{
    private static IBooksService _booksService;

    static TestContext(){
        var randomIsbnService = new RandomIsbnService();
        randomIsbnService.Prefix = "Test-ISBN";
        randomIsbnService.CountryCode = "-dk";
        var storeService = new StoreService();
        storeService.SetStock("books", new Isbn(4,5,6,7), 100);
        storeService.SetStock("books", new Isbn(4,5,6,8), 10);
        var booksService = new BooksService(randomIsbnService, storeService);
        _booksService = booksService;
    }
    public static IBooksService IBooksService(){
        return _booksService;
    }  

}
public class CreateBookTests
{
    private IBooksService _booksService;
    [SetUp]
    public void Setup()
    {
        _booksService = TestContext.IBooksService();
    }

    [Test]
    public void CreateBooksWithValidParamsGeneratesIsbn()
    {
        Dictionary<string, Object> empty= new Dictionary<string, Object>();
        Isbn generated = _booksService.CreateBook("Title1", 100, 19.99, empty);
        Assert.NotNull(generated);
    }
    [Test]
    public void CreateBooksWithInvalidParamsThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _booksService.CreateBook(null, -1, -1.1, null));
    }

}