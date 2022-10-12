using WordProcessor.Impl;
using NUnit.Framework;
namespace WordProcessor.Impl.Configurator.Test{

public class ConfiguratorTest
{
    [Test]
    public void testValidConfiguration1()
    {
        var configurator = new Configuration("c:\\_training\\config1.txt");
    }
    [Test]
    public void testValidConfiguration2()
    {
        var configurator = new Configuration("c:\\_training\\config2.txt");
    }
    [Test]
    public void testInValidConfiguration()
    {
        Assert.Throws<ArgumentException>(() => new Configuration("c:\\_training\\config3.txt"));

    }
    [Test]
    public void testConfigurationNotFound()
    {
        Assert.Throws<ArgumentException>(() => new Configuration("c:\\_training\\unknown.txt"));

    }

}
}