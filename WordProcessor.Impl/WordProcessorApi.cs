namespace WordProcessor.Api
{
    public interface Reader
    {
        string Read();
    }

    public interface Transformer
    {
        string Transform(string source);
    }

    public interface Analyzer
    {
        public Report Analyze(string input);
    }

    public interface Reporter
    {
        public void Write(Report report);
    }
    public class Report
    {
        public Report(string result, string detail, string configuration, DateTime created)
        {
            this.Configuration = configuration;
            this.Created = created;
            this.Detail = detail;
            this.Result = result;
        }
        public string Detail {get;} 
        public string Result {get;} 
        public string Configuration {get;} 
        public DateTime Created {get;} 
    }

}