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
    public class WordStartsWithAnalyzer: Analyzer
    {
        private string Configuration;
        private string StartsWith;
        public WordStartsWithAnalyzer(string configuration, string startsWith)
        {
            this.Configuration = configuration;
            this.StartsWith = startsWith;
        }
        public Report Analyze(string input)
        {

            int result = Array.FindAll(input.Split(" "), s => s.StartsWith(StartsWith)).Length;
            var report = new Report(result.ToString(), $"Number of words: {result}", this.Configuration, new DateTime());
            return report;
        }
    }

    public class WordContainsAnalyzer: Analyzer
    {
        private string Configuration;
        private string Contains;
        public WordContainsAnalyzer(string configuration, string contains)
        {
            this.Configuration = configuration;
            this.Contains = contains;
        }
        public Report Analyze(string input)
        {

            int result = Array.FindAll(input.Split(" "), s => s.Contains(Contains)).Length;
            var report = new Report(result.ToString(), $"Number of words: {result}", this.Configuration, new DateTime());
            return report;
        }
    }

}