using NUnit.Framework;
using Javacream.Books.API;
using Javacream.Books.Impl;
using Javacream.IsbnGenerator.API;
using Javacream.Store.API;


namespace Javacream.Publishing.Books.Warehouse.Test;


class IsbnServiceDummy : IIsbnService
{
    public Isbn Next()
    {
        return new Isbn(1,2,3,4);
    }
}
class StoreServiceDummy : IStoreService
{
    public int GetStock(string category, Object item)
    {
        return 42;
    }
    public void SetStock(string category, Object item, int stock)
    {
        //NOP
    }
}

static class UnitTestContext
{
    private static IBooksService _booksService;

    static UnitTestContext(){
        var booksService = new BooksService(new IsbnServiceDummy(), new StoreServiceDummy());
        _booksService = booksService;
    }
    public static IBooksService IBooksService(){
        return _booksService;
    }  

}
public class CreateBookUnitTests
{
    private IBooksService _booksService;
    [SetUp]
    public void Setup()
    {
        _booksService = UnitTestContext.IBooksService();
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