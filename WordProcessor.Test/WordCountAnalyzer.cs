using WordProcessor.Impl.Analyzers;
using NUnit.Framework;
namespace WordProcessor.Impl.Transformers.Test;

public class WordCountAnalyzerTest
{
    [Test]
    public void testAnalyzer()
    {
        string text = "Hello World! This is a very simple test string";
        var WordCountAnalyzer = new WordCountAnalyzer("test-configuration");
        var report = WordCountAnalyzer.Analyze(text);
        Assert.That(report.Result, Is.EqualTo("9") );
   
  }
}