using NUnit.Framework;
using Javacream.Books.API;
using Javacream.Books.Impl;

namespace Javacream.Publishing.Books.Warehouse.Test;

public class DatabaseTests
{
    [Test]
    public void TestPublishingContext()
    {
        using (var context = new PublishingContext())
        {
            context.Publishers.Add(new Publisher("Hugo"));
            context.SaveChanges();
        };
    }
}

