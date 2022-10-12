using NUnit.Framework;
using Moq;
using WordProcessor.Api;
namespace WordProcessor.Impl.Test;

public class WordCountImplTest
{
    [Test]
    public void testProcessor()
    {
      var reader = new Mock<Reader>();     
      reader.Setup((reader => reader.Read())).Returns("Hugo");
      var transformer = new Mock<Transformer>();     
      transformer.Setup((transformer => transformer.Transform(""))).Returns("Hugo");
      var analyzer = new Mock<Analyzer>();     
      analyzer.Setup((analyzer => analyzer.Analyze(""))).Returns(new Report("", "", "", DateTime.Now));
      var reporter = new Mock<Reporter>();
      reporter.Setup((reporter => reporter.Write(new Report("", "", "", DateTime.Now))));
      WordProcessorImpl impl = new WordProcessorImpl(reader.Object, transformer.Object, analyzer.Object, reporter.Object);     
    }
}