using Conti.Tom.Content.Interfaces;

namespace Conti.Tom.Content.Services;
public class ContentService : IContentService
{
    public string GetContent(string isbn)
    {
        if (isbn == null || isbn.Length == 0)
        {
            throw new ArgumentNullException();
        }
        if (isbn.Length < 7)
        {
            throw new ArgumentOutOfRangeException();
        }

        return $"ISBN: {isbn} has been processed";
    }
}
