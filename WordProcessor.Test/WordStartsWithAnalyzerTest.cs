using WordProcessor.Impl.Analyzers;
using NUnit.Framework;
namespace WordProcessor.Impl.Transformers.Test;

public class WordStartsWithAnalyzerTest
{
    [Test]
    public void testAnalyzer()
    {
        string text = "Hello World! This is a very simple test string";
        var WordStartsWithAnalyzer = new WordStartsWithAnalyzer("test-configuration", "s");
        var report = WordStartsWithAnalyzer.Analyze(text);
        Assert.That(report.Result, Is.EqualTo("2") );
   
  }
}