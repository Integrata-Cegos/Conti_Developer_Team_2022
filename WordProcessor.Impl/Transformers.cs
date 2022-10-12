using WordProcessor.Api;
using System.Text.RegularExpressions;
namespace WordProcessor.Impl.Transformers{

    public class NopTransformer: Transformer
    {
        public string Transform(string input)
        {
            return input;
        }

    }
    public class ToUpper: Transformer{
        public string Transform(string input)
        {
            return input.ToUpper();
        }
    }
    public class ToLower: Transformer{
        public string Transform(string input)
        {
            return input.ToLower();
        }
    }
    public class RemoveWhitespaces: Transformer{
        public string Transform(string input)
        {
            return Regex.Replace(input, "\\s", "");
        }
    }

}