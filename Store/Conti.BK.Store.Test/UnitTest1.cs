using NUnit.Framework;
using System;
using Conti.BK.Store;
using Conti.BK.Store.Impl;
using Conti.BK.Store.API;

namespace Conti.BK.Store.Test;

public class Tests
{
    private StoreService _store;
    private StoreService.StoreEntry _entriy;
    private Object _item;
    [SetUp]
    public void Setup()
    {
        _item = new Object();
        _store = new StoreService();
        _entriy = new StoreService.StoreEntry("TestCat",_item);
        _store._stock.Add(_entriy,5);
        
        _entriy = new StoreService.StoreEntry("TestCat2",_item);
        _store._stock.Add(_entriy,-4);
    }

    [Test]
    public void GetStockFromStoreShoudBe5()
    {
        int res = _store.GetStock("TestCat",_item);
        Assert.AreEqual(5, res);

    }
    [Test]
    public void GetStockFromStoreShoudNotBeMinus()
    {
        int res = _store.GetStock("TestCat2",_item);
        Assert.AreEqual(0, res);

    }
    [Test]
    public void GetStockFromStoreWithNoCat()
    {
        int res = _store.GetStock(null,_item);
        Assert.Throws<ArgumentException>(
    delegate { throw new ArgumentException(); });

    }
    [Test]
    public void GetStockFromStoreWithNoItem()
    {
        int res = _store.GetStock("TestCat2",null);
        Assert.Throws<ArgumentException>(
    delegate { throw new ArgumentException(); });

    }
}