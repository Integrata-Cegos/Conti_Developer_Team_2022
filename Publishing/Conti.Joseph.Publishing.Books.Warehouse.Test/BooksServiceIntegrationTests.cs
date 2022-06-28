using NUnit.Framework;
using Conti.Joseph.Books.API;
using Conti.Joseph.Books.Impl;
using Conti.Joseph.IsbnGenerator.API;
using Conti.Joseph.IsbnGenerator.Impl;
using Javacream.Store.API;
using Javacream.Store.Impl;


namespace Conti.Joseph.Publishing.Books.Warehouse.Test;


static class IntegrationTestContext
{
    private static IBooksService _booksService;

    static IntegrationTestContext(){
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
        _booksService = IntegrationTestContext.IBooksService();
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