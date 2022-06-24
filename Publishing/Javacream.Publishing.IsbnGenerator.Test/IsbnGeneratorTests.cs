using NUnit.Framework;
using Javacream.IsbnGenerator.API;
using Javacream.IsbnGenerator.Impl;


namespace Javacream.Publishing.IsbnGenerator.Test;

public class NextTests
{
    private IIsbnService? _isbnGenerator;
    [SetUp]
    public void Setup()
    {
        _isbnGenerator = new CounterIsbnService();
    }

    [Test]
    public void NextGeneratesNonEmptyIsbn()
    {
        Isbn isbn = _isbnGenerator.Next();
        Assert.NotNull(isbn);
    }
   [Test]
    public void NextGeneratesUniqueIsbns()
    {
        Isbn isbn1 = _isbnGenerator.Next();
        Isbn isbn2 = _isbnGenerator.Next();
        Assert.AreNotEqual(isbn1, isbn2);
    }
}
