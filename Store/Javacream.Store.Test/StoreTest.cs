using NUnit.Framework;
using Javacream.Store.API;
using Javacream.Store.Impl;
namespace Javacream.Store.Test;

public class GetStockTests
{
    private IStoreService? _storeService; 
    [SetUp]
    public void Setup()
    {
        _storeService = new DatabaseStoreService();    
    }
    [Test]
    public void GetStockWithCategoryBooksAndItemIsbn1RetrievesStockGreaterThanNull()
    {
        int stock = _storeService.GetStock("books", "ISBN1");
        Assert.GreaterOrEqual(stock, 0);
    }
   [Test]
    public void GetStockWithNullCategoryThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _storeService.GetStock(null, "item"));
    }

    [Test]
    public void GetStockWithNullItemThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _storeService.GetStock("null", null));
    }
}


public class SetStockTests
{
    private IStoreService? _storeService; 
    [SetUp]
    public void Setup()
    {
        _storeService = new DatabaseStoreService();    
    }

    [Test]    
    public void SetStockWithCategoryBooksAndItemIsbn1AndStock42IsOk()
    {
        _storeService.SetStock("Books", "Isbn1", 42);
    }
    [Test]    
    public void SetStockWithCategoryBooksAndItemIsbn1AndNegativeStockThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _storeService.SetStock("Books", "Isbn1", -42));
    }
    [Test]    
    public void SetStockWithNullCategoryThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _storeService.SetStock(null, "Isbn1", 42));
    }
    [Test]    
    public void SetStockWithNullItemThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _storeService.SetStock("cat", null, 42));
    }
    [Test]
    public void SetStockCreatesEntry([Values("books", "dvds")] string category, [Values("item1", "item2")] string item)
    {
        int expected = 42;
        _storeService.SetStock(category, item, expected);
        int stock = _storeService.GetStock(category, item);
        Assert.AreEqual(expected, stock);

    }

}
