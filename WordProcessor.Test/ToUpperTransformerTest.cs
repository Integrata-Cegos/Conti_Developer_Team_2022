using WordProcessor.Impl.Transformers;
using NUnit.Framework;
namespace WordProcessor.Impl.Transformers.Test;

public class ToUpperTransformerTest
{
    [Test]
    public void testTransformer()
    {
        string text = "Hello World!";
        var ToUpperTransformer = new ToUpper();
        string transformed = ToUpperTransformer.Transform(text);
        Assert.That(transformed, Is.EqualTo("HELLO WORLD!") );
   
  }
}