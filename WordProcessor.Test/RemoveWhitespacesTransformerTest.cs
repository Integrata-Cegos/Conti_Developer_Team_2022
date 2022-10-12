using WordProcessor.Impl.Transformers;
using NUnit.Framework;
namespace WordProcessor.Impl.Transformers.Test;

public class RemoveWhitespacesTransformerTest
{
    [Test]
    public void testTransformer()
    {
        string text = "Hello W\tor\rl\nd!";
        var RemoveWhitespacesTransformer = new RemoveWhitespaces();
        string transformed = RemoveWhitespacesTransformer.Transform(text);
        Assert.That(transformed, Is.EqualTo("HelloWorld!") );
   
  }
}