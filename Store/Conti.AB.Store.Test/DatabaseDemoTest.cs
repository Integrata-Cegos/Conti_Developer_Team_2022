using NUnit.Framework;
using Conti.AB.Store.API;
using Conti.AB.Store.Impl;

namespace Conti.AB.Store.Test;

public class DatabaseDemoTests
{
    [Test]
    public void TestDbAccess()
    {
        DatabaseDemo demo = new DatabaseDemo();
        demo.DoDemo();
    }
}