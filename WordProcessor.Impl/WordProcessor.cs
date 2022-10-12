using WordProcessor.Api;
namespace WordProcessor.Impl{
    public class WordProcessorImpl
    {
        public Reader Reader;
        public  Transformer Transformer;
        public  Analyzer Analyzer;
        public  Reporter Reporter;


        public WordProcessorImpl(Reader reader, Transformer transformer, Analyzer analyzer, Reporter reporter)
        {
            this.Reader = reader;
            this.Transformer = transformer;
            this.Analyzer = analyzer;
            this.Reporter = reporter;

        }
        public void Process(){
            string input = this.Reader.Read();
            string transformed = this.Transformer.Transform(input);
            Report report = this.Analyzer.Analyze(transformed);
            this.Reporter.Write(report);
        }
    }
}