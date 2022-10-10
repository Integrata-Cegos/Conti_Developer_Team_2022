using NUnit.Framework;
using GU.Books.API;
using GU.Books.Impl;
using GU.IsbnGenerator.API;
using GU.IsbnGenerator.Impl;
using GU.Store.API;
using GU.Store.Impl;


namespace GU.Publishing.Books.Warehouse.Test;


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