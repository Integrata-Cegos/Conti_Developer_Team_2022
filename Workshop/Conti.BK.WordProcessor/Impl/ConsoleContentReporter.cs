namespace Conti.BK.WordProcessor.Content;

public class ConsoleContentReporter: IContentReporter
{
    public void Report(string output){
        Console.WriteLine(output);
    }
}