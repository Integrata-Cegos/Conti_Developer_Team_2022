namespace WorkShopProcessor;

public interface IWorkShopReader
{
    string ConsoleRead();
    string FileRead(string fileName);
}