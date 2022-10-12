namespace Conti.BK.WordProcessor.Content;

public class WordContainsContentAnalyzer: IContentAnalyzer
{
    public void Analyze(string input, out string output, string param){
        var wordSplit = input.Split(new char[]{' ','\n','\r'});
        int i = 0;
        foreach (var word in wordSplit)
        {
            if(word.Contains(param)){
                i++;
            }
        }
        output = i.ToString();
    }
}