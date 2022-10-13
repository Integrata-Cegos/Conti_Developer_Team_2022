// See https://aka.ms/new-console-template for more information
using Conti.BK.WordProcessor.Content;
using Conti.BK.WordProcessor.Config;
Console.WriteLine("Hello, World!");
IConfigReader _configReader = new FileConfigReader("config.txt");
ContentConfig _config = _configReader.Read();

IContentReader _reader = null;
IContentTransformer _transformer = null;
IContentAnalyzer _analayzer = null;
IContentReporter _reporter = null;

switch (_config.readerType)
{
    case ReaderType.Console:
        _reader = new ConsoleContentReader();
        break;
    case ReaderType.File:
        _reader = new FileContentReader(_config.ReaderParam);
        break;
}
switch (_config.transformerType)
{
    case TransformerType.ToUpper:
        _transformer = new ToUpperContentTransformer();
        break;
    case TransformerType.ToLower:
        _transformer = new ToLowerContentTransformer();
        break;
    case TransformerType.RemoveWhitespace:
        _transformer = new RemoveWhitespaceContentTransformer();
        break;
    case TransformerType.None:
        _transformer = null;
        break;
}
switch (_config.analyzerType)
{
    case AnalyzerType.WordCount:
        _analayzer = new WordCountContentAnalyzer();
        break;
    case AnalyzerType.WordStartsWith:
        _analayzer = new WordStartsWithContentAnalyzer();
        break;
    case AnalyzerType.WordContains:
        _analayzer = new WordContainsContentAnalyzer();
        break;
    case AnalyzerType.LetterCount:
        _analayzer = new LetterCountContentAnalyzer();
        break;
}
switch (_config.reporterType)
{
    case ReporterType.Console:
        _reporter = new ConsoleContentReporter();
        break;
    case ReporterType.File:
        _reporter = new FileContentReporter("Result.txt");
        break;
}
Console.WriteLine("");
var fromRead = _reader.Read();
var fromTransform = fromRead;
if(_transformer != null){
    fromTransform = _transformer.Transform(fromRead);
}
string fromAnalyze;
_analayzer.Analyze(fromTransform,out fromAnalyze,_config.AnalyzerParam);
_reporter.Report(fromAnalyze);

