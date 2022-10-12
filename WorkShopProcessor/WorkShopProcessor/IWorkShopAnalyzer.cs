namespace WorkShopProcessor;

public interface IWorkShopAnalyzer
{
    string LetterCount(string input);
    string WordCount(string input);
    string WordContains(string input, string containString);
    string WordStartsWith(string input, string startString);
}