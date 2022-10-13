namespace Conti.BK.WordProcessor.Content;

public class FileContentReader: IContentReader
{
    public string Read(){
        return File.ReadAllText(path);
    }
    public string path;
    public FileContentReader(string path){
        this.path = path;
    }
}