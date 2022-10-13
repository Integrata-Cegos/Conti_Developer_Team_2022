namespace Conti.BK.WordProcessor.Content;

public class ToUpperContentTransformer: IContentTransformer
{
    public string Transform(string input){
        return input.ToUpper();
    }
}