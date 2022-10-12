namespace WorkShopProcessor;

public interface IWorkShopTransformer
{
    string RemoveWhiteSpaces(string input);
    string ToLower(string input);
    string ToUpper(string input);
}