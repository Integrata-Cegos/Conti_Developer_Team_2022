namespace Conti.BK.WordProcessor.Content;

public class LetterCountContentAnalyzer: IContentAnalyzer
{
    public void Analyze(string input, out string output, string param = ""){
        Dictionary<char,int> result = new Dictionary<char, int>();
        foreach (char c in input)
        {
            if(result.ContainsKey(c)){
                result[c] += 1;
            }else{
                result.Add(c,1);
            }
        }
        string str = "|Char\t|Count\t|";
        foreach (var item in result)
        {
            str += $" \n|{item.Key}\t|{item.Value}\t|";
        }
        output = str;
    }
}