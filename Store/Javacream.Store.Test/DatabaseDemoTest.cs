using NUnit.Framework;
using Javacream.Store.API;
using Javacream.Store.Impl;
namespace Javacream.Store.Test;

public class DatabaseDemoTests
{
    [Test]
    public void TestDbAccess()
    {
        DatabaseDemo demo = new DatabaseDemo();
        demo.DoDemo();
    }
}
