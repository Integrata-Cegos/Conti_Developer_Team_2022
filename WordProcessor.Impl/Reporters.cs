using WordProcessor.Api;
using System.Text.RegularExpressions;
namespace WordProcessor.Impl.Reporters{
    public class ConsoleReporter: Reporter
    {
        public void Write(Report report)
        {
            Console.WriteLine(report.Result);
            Console.WriteLine(report.Detail);
            Console.WriteLine(report.Created);
            Console.WriteLine(report.Configuration);
        }
    }
    public class FileReporter: Reporter
    {
        private string OutputFile;

        public FileReporter(string outputFile)
        {
            this.OutputFile = outputFile;
        }
        public void Write(Report report)
        {
            string[] output = {report.Result, report.Detail, report.Created.ToLongTimeString(), report.Configuration};
            File.WriteAllLines(this.OutputFile, output);
        }
    }
}

