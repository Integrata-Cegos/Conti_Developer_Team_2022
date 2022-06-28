using NUnit.Framework;
using Conti.AB.Books.API;
using Conti.AB.Books.Impl;
using Conti.AB.IsbnGenerator.API;
using Conti.AB.Store.API;

namespace Conti.AB.Publishing.Books.Warehouse.Test;

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
    public static IBooksService IBooksService(){
        var booksService = new BooksService(new IsbnServiceDummy(), new StoreServiceDummy());
        return booksService;
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