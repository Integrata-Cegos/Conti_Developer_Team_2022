namespace Conti.BK.WordProcessor.Config;

public interface IConfigReader
{
    public ContentConfig Read();
}

public enum ReaderType
    {
        Console,
        File
    }
public enum TransformerType
    {
        ToUpper,
        ToLower,
        RemoveWhitespace,
        None
    }
public enum AnalyzerType
    {
        WordCount,
        WordStartsWith,
        WordContains,
        LetterCount
    }
public enum ReporterType
    {
        Console,
        File
    }

public class ContentConfig{
    public ReaderType readerType = ReaderType.Console;
    public string ReaderParam = String.Empty;
    public TransformerType transformerType = TransformerType.None;
    public string TransformerParam = String.Empty;
    public AnalyzerType analyzerType = AnalyzerType.WordCount;
    public string AnalyzerParam = String.Empty;
    public ReporterType reporterType = ReporterType.Console;
    public string ReporterParam = String.Empty;
}