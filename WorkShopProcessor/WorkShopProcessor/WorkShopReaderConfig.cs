using System.Text.RegularExpressions;

namespace WorkShopProcessor;

public class WorkShopReaderConfig
{
    public string Reader { get; set; }
    public string Transformer { get; set; }
    public string Analyzer { get; set; }
    public string Reporter { get; set; }

    public WorkShopReaderConfig(string fileName)
    {
        if (File.Exists(fileName))
        {
            List<string> file = File.ReadAllLines(fileName).ToList();
            foreach (var item in file)
            {
                if (item.StartsWith("Reader="))
                {
                    Reader = Regex.Replace(item, "(.*=)", "");
                }
                if (item.StartsWith("Transformer="))
                {
                    Transformer = Regex.Replace(item, "(.*=)", "");
                }
                if (item.StartsWith("Analyzer="))
                {
                    Analyzer = Regex.Replace(item, "(.*=)", "");
                }
                if (item.StartsWith("Reporter="))
                {
                    Reporter = Regex.Replace(item, "(.*=)", "");
                }
            }
            if (Reader == null || Transformer == null || Analyzer == null || Reporter == null)
            {
                throw new Exception("Configuration Error!");
            }
        }
        else
        {
            throw new Exception("Config File not found!");
        }
    }


}
