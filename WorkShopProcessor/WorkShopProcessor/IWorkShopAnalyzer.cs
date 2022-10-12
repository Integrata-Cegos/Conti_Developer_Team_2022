namespace WorkShopProcessor;

public interface IWorkShopAnalyzer
{
    string LetterCount(string input);
    int WordCount(string input);
    int WordsContains(string input, string containString);
    int WordStartsWith(string input, string startString);
}