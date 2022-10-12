using WordProcessor.Impl.Analyzers;
using WordProcessor.Impl.Transformers;
using WordProcessor.Impl.Readers;
using WordProcessor.Impl.Reporters;
using WordProcessor.Api;
namespace WordProcessor.Impl{
    public class Configuration
    {
        public Reader? Reader;
        public  Transformer? Transformer;
        public  Analyzer? Analyzer;
        public  Reporter? Reporter;

        private String ConfigurationString;
        public Configuration(string configFileName)
        {
            try{
                string[] lines = File.ReadAllLines(configFileName);
                this.ConfigurationString = String.Join(",", lines);
                ConfigureReader(lines[0].Split("=")[1]);
                ConfigureTransformer(lines[1].Split("=")[1]);
                ConfigureAnalyzer(lines[2].Split("=")[1]);
                ConfigureReporter(lines[3].Split("=")[1]);

            }
            catch(FileNotFoundException)
            {
                throw new ArgumentException($"invalid file name: {configFileName}");
            }
            catch(Exception)
            {
                throw new ArgumentException($"invalid configuration: {configFileName}");
            }
        }

        private void ConfigureReader(string configuration){
            try{
                if (configuration.StartsWith("Console"))
                {
                    this.Reader = new ConsoleReader();
                }
                else if (configuration.StartsWith("File"))
                {
                    string param = configuration.Split(";")[1];
                    this.Reader = new FileReader(param);
                }else
                {
                    throw new ArgumentException($"invalid reader configuration: {configuration}");
                }
            }
            catch(Exception)
            {
                throw new ArgumentException($"invalid reader configuration: {configuration}");
            }
        }

        private void ConfigureTransformer(string configuration){
            try{
                if (configuration.StartsWith("ToUpper"))
                {
                    this.Transformer = new ToUpper();
                }
                else if (configuration.StartsWith("ToLower"))
                {
                    this.Transformer = new ToLower();
                }
                else if (configuration.StartsWith("RemoveWhitespaces"))
                {
                    this.Transformer = new RemoveWhitespaces();
                }
                else if (configuration.StartsWith("None"))
                {
                    this.Transformer = new NopTransformer();
                }
                else
                {
                    throw new ArgumentException($"invalid transformer configuration: {configuration}");
                }
                
            }
            catch(Exception)
            {
                throw new ArgumentException($"invalid transformer configuration: {configuration}");
            }
        }
        private void ConfigureAnalyzer(string configuration){
            try{
                if (configuration.StartsWith("WordCount"))
                {
                    this.Analyzer = new WordCountAnalyzer(this.ConfigurationString);
                }
                else if (configuration.StartsWith("LetterCount"))
                {
                    this.Analyzer = new LetterCountAnalyzer(this.ConfigurationString);
                }
                else if (configuration.StartsWith("WordStartsWith"))
                {
                    string param = configuration.Split(";")[1];
                    this.Analyzer = new WordStartsWithAnalyzer(this.ConfigurationString, param);
                }
                else if (configuration.StartsWith("WordContains"))
                {
                    string param = configuration.Split(";")[1];
                    this.Analyzer = new WordContainsAnalyzer(this.ConfigurationString, param);
                }
                else
                {
                    throw new ArgumentException($"invalid analyzer configuration: {configuration}");
                }
                    
            }
            catch(Exception)
            {
                throw new ArgumentException($"invalid analyzer configuration: {configuration}");
            }
    }
        private void ConfigureReporter(string configuration){
            try{
                if (configuration.StartsWith("Console"))
                {
                    this.Reporter = new ConsoleReporter();
                }
                else if (configuration.StartsWith("File"))
                {
                    string param = configuration.Split(";")[1];
                    this.Reporter = new FileReporter(param);
                }else
                {
                    throw new ArgumentException($"invalid reporter configuration: {configuration}");
                }
            }
            catch(Exception)
            {
                throw new ArgumentException($"invalid reporter configuration: {configuration}");
            }
        }
        }

    }
