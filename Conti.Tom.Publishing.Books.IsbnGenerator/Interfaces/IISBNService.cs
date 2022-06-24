using Conti.Tom.Publishing.Books.IsbnGenerator.Models;

namespace Conti.Tom.Publishing.Books.IsbnGenerator.Interfaces;

public interface IISBNService
{
    ISBN Next();
}