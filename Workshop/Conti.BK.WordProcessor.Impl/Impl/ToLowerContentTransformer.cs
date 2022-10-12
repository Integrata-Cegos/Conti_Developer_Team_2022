namespace Conti.BK.WordProcessor.Content;

public class ToLowerContentTransformer: IContentTransformer
{
    public string Transform(string input){
        return input.ToLower();
    }
}