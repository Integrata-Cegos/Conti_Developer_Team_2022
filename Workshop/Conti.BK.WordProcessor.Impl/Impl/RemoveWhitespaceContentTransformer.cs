namespace Conti.BK.WordProcessor.Content;
using System.Linq;
public class RemoveWhitespaceContentTransformer: IContentTransformer
{
    public string Transform(string input){
        return String.Concat(input.Where(x => !Char.IsWhiteSpace(x)));
    }
}