using NUnit.Framework;
using Javacream.Books.API;
using Javacream.Books.Impl;
using Javacream.IsbnGenerator.API;
using Javacream.IsbnGenerator.Impl;


namespace Javacream.Publishing.Books.Warehouse.Test;


public static class TestContext
{
    private static IBooksService _booksService;

    public static TestContext(){
        //Erzeugen des BooksService mit allen Dependencies...
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
        _booksService = TestContext.IBooksService();
    }

    [Test]
    public void CreateBooksWithValidParamsGeneratesIsbn()
    {
        Assert.Pass();
    }
    [Test]
    public void CreateBooksWithInvalidParamsThrowsArgumentException()
    {
        Assert.Pass();
    }

}