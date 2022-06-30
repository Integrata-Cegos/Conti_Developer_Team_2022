namespace Conti.Tom.Publishing.Tests;

public class CounterISBNGeneratorTests
{
    private string ISBN = "Test-Isbn";
    private string CountryCode = "-test";
    private IISBNService _isbnGenerator;
    [SetUp]
    public void Setup()
    {
        RandomISBNService isbnService = new RandomISBNService();
        isbnService.Prefix = ISBN;
        isbnService.CountryCode = CountryCode;
        _isbnGenerator = isbnService;
    }

    [Test]
    public void NextGeneratesNonEmptyIsbn()
    {
        ISBN isbn = _isbnGenerator.Next();
        Assert.NotNull(isbn);
    }
    [Test]
    public void NextGeneratesUniqueIsbns()
    {
        ISBN isbn1 = _isbnGenerator.Next();
        ISBN isbn2 = _isbnGenerator.Next();
        Assert.That(isbn2, Is.Not.EqualTo(isbn1));
    }

    [Test]
    public void GeneratedIsbnStartsWithTestIsbn()
    {
        ISBN isbn = _isbnGenerator.Next();
        string isbnAsString = isbn.ToString();
        Assert.True(isbnAsString.StartsWith(ISBN));
    }

}