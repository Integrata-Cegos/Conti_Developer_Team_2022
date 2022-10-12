namespace WorkShopProcessor;

public interface IWorkShopReporter
{
    void ReportToConsole(string input);
    void ReportToFile(string input, string fileName);
}