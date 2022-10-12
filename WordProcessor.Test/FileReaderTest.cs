using WordProcessor.Impl.Readers;
using NUnit.Framework;
namespace WordProcessor.Impl.Readers.Test;

public class FileReaderTest
{
    [Test]
    public void testReader()
    {
        var reader = new FileReader("c:\\_training\\input.txt");
        string input = reader.Read();
        Assert.That(input.StartsWith("Hello"));
   
  }
}