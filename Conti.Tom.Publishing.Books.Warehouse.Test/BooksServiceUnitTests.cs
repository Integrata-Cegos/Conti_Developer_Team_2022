namespace Conti.Tom.Publishing.Books.Warehouse.Test;

class IsbnServiceDummy : IISBNService
{
    public string Prefix { get; set; } = "ISBN:";
    public string CountryCode { get; set; } = "-DE";

    public ISBN Next()
    {
        return new ISBN(1, 2, 3, 4);
    }
}
class StoreServiceDummy : IStoreService
{
    public int GetStock(string category, object item)
    {
        return 42;
    }

    public void SetStock(string category, object item, int stock)
    {
        throw new NotImplementedException();
    }
}

static class BooksServiceUnitTestContext
{
    public static IBooksService BooksService { get { return new BooksService(new IsbnServiceDummy(), new StoreServiceDummy()); } }

}

public class CreateUnitBookTests
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