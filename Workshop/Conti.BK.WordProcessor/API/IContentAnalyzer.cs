namespace Conti.BK.WordProcessor.Content;

public interface IContentAnalyzer
{
    public void Analyze(string input, out string output, string param);
}