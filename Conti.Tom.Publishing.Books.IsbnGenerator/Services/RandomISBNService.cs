using Conti.Tom.Publishing.Books.IsbnGenerator.Models;

namespace Conti.Tom.Publishing.Books.IsbnGenerator.Services;

public class RandomISBNService : BaseISBNService
{
    private Random random = new Random();

    public override ISBN Next()
    {
        return new ISBN(Prefix, CountryCode, 1, 2, 3, random.Next(0, 999));
    }
}
