using WordProcessor.Impl.Reporters;
using WordProcessor.Api;
using NUnit.Framework;
namespace WordProcessor.Impl.Reporters.Test;

public class ConsoleReporterTest
{
    Report testReport = new Report("A", "B", "C", DateTime.Now);
    [Test]
    public void testReporter()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var ConsoleReporter = new ConsoleReporter();
        ConsoleReporter.Write(testReport);
        Assert.That(stringWriter.ToString().StartsWith("A"));
   
  }
}