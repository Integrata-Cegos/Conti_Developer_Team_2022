using WordProcessor.Impl.Analyzers;
using NUnit.Framework;
namespace WordProcessor.Impl.Transformers.Test;

public class LetterCountAnalyzerTest
{
    [Test]
    public void testAnalyzer()
    {
        string text = "Hello World! This is a very simple test string";
        var LetterCountAnalyzer = new LetterCountAnalyzer("test-configuration");
        var report = LetterCountAnalyzer.Analyze(text);
        Assert.That(report.Result.Contains("[e, 4]"));
        Assert.That(report.Result.Contains("[o, 2]"));
   
  }
}