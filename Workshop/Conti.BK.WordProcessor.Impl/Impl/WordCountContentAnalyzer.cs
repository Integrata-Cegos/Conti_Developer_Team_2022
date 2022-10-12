namespace Conti.BK.WordProcessor.Content;

public class WordCountContentAnalyzer: IContentAnalyzer
{
    public void Analyze(string input, out string output, string param = ""){
        var wordSplit = input.Split(new char[]{' ','\n','\r'});
        int i = 0;
        foreach (var word in wordSplit)
        {
            if(word.Length >= 1){
                i++;
            }
        }
        output = i.ToString();
    }
}