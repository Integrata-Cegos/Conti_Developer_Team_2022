namespace Conti.BK.WordProcessor.Content;

public class FileContentReporter: IContentReporter
{
    public void Report(string output){
        File.WriteAllText(path,output);
    }
    public string path;
    public FileContentReporter(string path){
        this.path = path;
    }
}