namespace Conti.Tom.Publishing.Books.Warehouse.Test;

static class UnitTestMoqContext
{
    public static IBooksService IBooksService()
    {
        var iss = new Mock<IStoreService>();
        iss.Setup(storeService => storeService.GetStock("books", "Isbn1")).Returns(42);
        var iis = new Mock<IISBNService>();
        iis.Setup(o => o.Next()).Returns(new ISBN(1, 2, 3, 4));
        var booksService = new BooksService(iis.Object, iss.Object);
        return booksService;
    }

}
internal class BooksServiceUnitWithMoqTests
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
