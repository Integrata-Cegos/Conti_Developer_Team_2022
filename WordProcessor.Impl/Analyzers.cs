using WordProcessor.Api;

namespace WordProcessor.Impl.Analyzers
{
    public class WordCountAnalyzer: Analyzer
    {
        private string Configuration;
        public WordCountAnalyzer(string configuration)
        {
            this.Configuration = configuration;
        }
        public Report Analyze(string input)
        {
            string[] numberOfWords = input.Split(" ");
            int result = numberOfWords.Length;
            var report = new Report(result.ToString(), $"Number of words: {result}", this.Configuration, new DateTime());
            return report;
        }
    }
}