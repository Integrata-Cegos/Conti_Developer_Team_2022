using WordProcessor.Impl.Reporters;
using WordProcessor.Api;
using NUnit.Framework;
namespace WordProcessor.Impl.Reporters.Test;

public class FileReporterTest
{
    Report testReport = new Report("A", "B", "C", DateTime.Now);
    [Test]
    public void testReporter()
    {
        var FileReporter = new FileReporter("c:\\_training\\report.txt");
        FileReporter.Write(testReport);
   
  }
}