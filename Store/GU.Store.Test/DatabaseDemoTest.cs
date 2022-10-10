using NUnit.Framework;
using GU.Store.API;
using GU.Store.Impl;
namespace GU.Store.Test;

public class DatabaseDemoTests
{
    [Test]
    public void TestDbAccess()
    {
        DatabaseDemo demo = new DatabaseDemo();
        demo.DoDemo();
    }
}