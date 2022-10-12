namespace Conti.BK.WordProcessor.Content;

public class WordStartsWithContentAnalyzer: IContentAnalyzer
{
    public void Analyze(string input, out string output, string param){
        var wordSplit = input.Split(new char[]{' ','\n','\r'});
        int i = 0;
        foreach (var word in wordSplit)
        {
            if(word.StartsWith(param)){
                i++;
            }
        }
        output = i.ToString();
    }
}