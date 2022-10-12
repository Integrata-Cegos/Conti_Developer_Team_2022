using NUnit.Framework;
using Conti.BK.Books.API;
using Conti.BK.Books.Impl;
using Conti.BK.IsbnGenerator.API;
using Conti.BK.Store.API;
using Moq;

namespace Conti.BK.Publishing.Books.Warehouse.Test;
static class UnitTestMoqContext
{
    public static IBooksService IBooksService(){
        var iss = new Mock<IStoreService>();
        iss.Setup(storeService => storeService.GetStock("books", "Isbn1")).Returns(42);
        var iis = new Mock<IIsbnService>();
        iis.Setup(o => o.Next()).Returns(new Isbn(1,2,3,4));
        var booksService = new BooksService(iis.Object, iss.Object);
        return booksService;
    }  

}
public class CreateBookUnitMoqTests
{
    private IBooksService _booksService;
    [SetUp]
    public void Setup()
    {
        _booksService = UnitTestMoqContext.IBooksService();
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