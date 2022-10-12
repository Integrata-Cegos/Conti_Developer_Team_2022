namespace Conti.BK.WordProcessor.Content;

public class ConsoleContentReader: IContentReader
{
    public string Read(){
        Console.WriteLine("Enter content:");
        string? consoleRead = Console.ReadLine();
        if(consoleRead == String.Empty || consoleRead == null){
            consoleRead = Read();
        }
        if(consoleRead == null){
            throw new Exception("FETAL CONSOLE READ");
        }
        return (string)consoleRead;
    }

}