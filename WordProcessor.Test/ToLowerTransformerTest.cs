using WordProcessor.Impl.Transformers;
using NUnit.Framework;
namespace WordProcessor.Impl.Transformers.Test;

public class ToLowerTransformerTest
{
    [Test]
    public void testTransformer()
    {
        string text = "Hello World!";
        var ToLowerTransformer = new ToLower();
        string transformed = ToLowerTransformer.Transform(text);
        Assert.That(transformed, Is.EqualTo("hello world!") );
   
  }
}