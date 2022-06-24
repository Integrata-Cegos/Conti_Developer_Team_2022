using NUnit.Framework;
using Conti.Guido.Store.API;
using Conti.Guido.Store.Impl;
namespace Conti.Guido.Store.Test;

public class GetStockTests
{
    private IStoreService? _storeService; 
    [SetUp]
    public void Setup()
    {
        _storeService = new StoreService();    
    }


    [Test]
    public void GetStockWithCategoryBooksAndItemIsbn1RetrievesStockGreaterThanNull()
    {
        int stock = _storeService.GetStock("Books", "Isbn1");
        Assert.GreaterOrEqual(0, stock);
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
        _storeService = new StoreService();    
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
    public void SetStockWithCategoryBooksAndItemIsbn1AndStock42CreatesEntry()
    {
        int expected = 42;
        string category = "Books";
        string item = "Isbn1";
        _storeService.SetStock(category, item, expected);
        int stock = _storeService.GetStock(category, item);
        Assert.AreEqual(expected, stock);

    }

}
