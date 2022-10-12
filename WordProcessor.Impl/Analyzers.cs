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
            input = input.Replace("\n", " ");
            input = input.Replace("\r\n", " ");
            string[] numberOfWords = input.Split(" ");
            int result = numberOfWords.Length;
            var report = new Report(result.ToString(), $"Number of words: {result}", this.Configuration, DateTime.Now);
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

            input = input.Replace("\n", " ");
            input = input.Replace("\r\n", " ");
            input.Trim();
            int result = Array.FindAll(input.Split(" "), s => s.StartsWith(StartsWith)).Length;
            var report = new Report(result.ToString(), $"Number of words starting with {this.StartsWith}: {result}", this.Configuration, DateTime.Now);
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
            input = input.Replace("\n", " ");
            input = input.Replace("\r\n", " ");
            input.Trim();
            int result = Array.FindAll(input.Split(" "), s => s.Contains(Contains)).Length;
            var report = new Report(result.ToString(), $"Number of words containing {this.Contains}: {result}", this.Configuration, DateTime.Now);
            return report;
        }
    }

    public class LetterCountAnalyzer: Analyzer
    {
        private string Configuration;
        public LetterCountAnalyzer(string configuration)
        {
            this.Configuration = configuration;
        }
        public Report Analyze(string input)
        {

            var result = new Dictionary<char, int>();
            foreach (char c in input)
            {   int number;
                var containsChar = result.TryGetValue(c, out number);
                if (containsChar)
                {
                    number++;
                    result[c] = number;
                }
                else
                {
                    result.Add(c, 1);
                }
            }
            var resultString = string.Join(Environment.NewLine, result);
            var report = new Report(resultString, $"LetterCount: {resultString}", this.Configuration, DateTime.Now);
            return report;
        }
    }


}