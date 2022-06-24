using NUnit.Framework;
using System;
using ContiLS.IsbnGenerator.API;
using ContiLS.IsbnGenerator.Impl;


namespace ContiLS.Publishing.IsbnGenerator.Test;

public class NextTests
{
    private string ISBN= "Test-Isbn";
    private string CountryCode = "-test";
    private IIsbnService? _isbnGenerator;
    [SetUp]
    public void Setup()
    {
        CounterIsbnService isbnService = new CounterIsbnService();
        isbnService.Prefix = ISBN;
        isbnService.CountryCode = CountryCode;
        _isbnGenerator = isbnService;
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

    [Test]
    public void GeneratedIsbnStartsWithTestIsbn()
    {
        Isbn isbn = _isbnGenerator.Next();
        string isbnAsString = isbn.ToString();
        Assert.True(isbnAsString.StartsWith(ISBN));
    }

}