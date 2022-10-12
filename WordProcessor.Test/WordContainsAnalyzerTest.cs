using WordProcessor.Impl.Analyzers;
using NUnit.Framework;
namespace WordProcessor.Impl.Transformers.Test;

public class WordContainsAnalyzerTest
{
    [Test]
    public void testAnalyzer()
    {
        string text = "Hello World! This is a very simple test string";
        var WordContainsAnalyzer = new WordContainsAnalyzer("test-configuration", "is");
        var report = WordContainsAnalyzer.Analyze(text);
        Assert.That(report.Result, Is.EqualTo("2") );
   
  }
}