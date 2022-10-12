using WordProcessor.Impl.Readers;
using NUnit.Framework;
namespace WordProcessor.Impl.Readers.Test;

public class ConsoleReaderTest
{
    [Test]
    public void testReader()
    {
        string text = "Hello World!";
        var stringReader = new StringReader(text+"\n");
        var stringWriter = new StringWriter();
        Console.SetIn(stringReader);
        Console.SetOut(stringWriter);
        var reader = new ConsoleReader();
        string input = reader.Read();
        Assert.That(stringWriter.ToString(), Is.EqualTo("Enter text, empty line to finish:\r\n") );
        Assert.That(input, Is.EqualTo(text));
   
  }
}