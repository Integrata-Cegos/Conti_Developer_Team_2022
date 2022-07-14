namespace Conti.Tom.Content.Test;

static class UnitTestMoqContext
{
    public static IContentService IContentService()
    {
        return new ContentService();
    }

}

public class ContentServiceTest
{
    private IContentService _contentService;
    [SetUp]
    public void Setup()
    {
        _contentService = UnitTestMoqContext.IContentService();
    }

    [Test]
    public void GetContentWithNullArgumentReturnsException()
    {
        Assert.Throws<ArgumentNullException>(() => _contentService.GetContent(null));
    }

    [Test]
    public void GetContentWithTooShortArgumentReturnsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _contentService.GetContent("1-2-3-"));
    }

    [Test]
    public void GetContentWithCorrectISBNReturnsString()
    {
        string isbn = "1-2-3-4";
        var returnvalue = _contentService.GetContent(isbn);
        if (returnvalue.Contains(isbn))
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
        Assert.NotNull(returnvalue);
    }

}