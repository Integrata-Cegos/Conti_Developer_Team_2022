namespace Conti.BK.WordProcessor.Content;

public class FileConfigReader: IConfigReader
{
    public string path;
    public FileConfigReader(string path){
        this.path = path;
    }
    public ContentConfig Read(){
        ContentConfig config = new ContentConfig();
        var fileContent = File.ReadAllLines(path);
        foreach (var line in fileContent)
        {
            var part = line.Split(new char[]{'=',';'});
            switch (part[0])
            {
                case "Reader":
                    switch (part[1])
                    {
                        case "Console":
                            config.readerType = ReaderType.Console;
                            break;
                        case "File":
                            config.readerType = ReaderType.File;
                            if(part.Count() < 3){
                                throw new Exception("Check Config. No Parameter set for Reader.");
                            }
                            config.ReaderParam = part[2];
                            break;
                        default:
                            throw new Exception("No reader called "+part[1]);
                    }
                    break;
                case "Transformer":
                    switch (part[1])
                    {
                        case "ToUpper":
                            config.transformerType = TransformerType.ToUpper;
                            break;
                        case "ToLower":
                            config.transformerType = TransformerType.ToLower;
                            break;
                        case "RemoveWhitespace":
                            config.transformerType = TransformerType.RemoveWhitespace;
                            break;
                        case "None":
                            break;
                        default:
                            throw new Exception("No transformer called "+part[1]);
                    }
                    break;
                case "Analyzer":
                    switch (part[1])
                    {
                        case"WordCount":
                            config.analyzerType = AnalyzerType.WordCount;
                            break;
                        case "WordStartsWith":
                            config.analyzerType = AnalyzerType.WordStartsWith;
                            if(part.Count() < 3){
                                throw new Exception("Check Config. No Parameter set for Analyzer.");
                            }
                            config.AnalyzerParam = part[2];
                            break;
                        case "WordContains":
                            config.analyzerType = AnalyzerType.WordContains;
                            if(part.Count() < 3){
                                throw new Exception("Check Config. No Parameter set for Analyzer.");
                            }
                            config.AnalyzerParam = part[2];
                            break;
                        case "LetterCount":
                            config.analyzerType = AnalyzerType.LetterCount;
                            break;
                        default:
                            throw new Exception("No analyzer called "+part[1]);
                    }
                    break;
                case "Reporter":
                    switch (part[1])
                    {
                        case "Console":
                            config.reporterType = ReporterType.Console;
                            break;
                        case "File":
                            config.reporterType = ReporterType.File;
                            if(part.Count() < 3){
                                throw new Exception("Check Config. No Parameter set for Reporter.");
                            }
                            config.ReporterParam = part[2];
                            break;
                        default:
                            throw new Exception("No reporter is called "+part[1]);
                    }
                    break;
                default:
                    Console.WriteLine("Warning: Check Config File!");
                    break;
            }
        }
        return config;
    }
    
}
/*
Reader=Console
Transformer=ToUpper
Analyzer=WordStartsWith;A
Reporter=Console
*/
