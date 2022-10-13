using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopProcessor;
public class WordProcessor
{
    public WorkShopReaderConfig Config { get; set; } = new("SampleConfig1.cfg");

    public WordProcessor(WorkShopReaderConfig workShopReaderConfig)
    {
        Config = workShopReaderConfig;
    }
    public string Data { get; set; }
    public string Analysed { get; set; }
    public void Read()
    {
        WorkShopReader reader = new();

        if (Config.Reader == "Console")
        {
            Data = reader.ConsoleRead();
        }
        else if (Config.Reader.StartsWith("File"))
        {
            Data = reader.FileRead(Config.Reader.Substring(5));
        }
        else
        {
            throw new Exception("Reader Configuration Error!");
        }

    }

    public void Transform()
    {
        if (Config.Transformer == "None") return;

        try
        {
            WorkShopTransformer transformer = new ();
            var transformedData = typeof(WorkShopTransformer).GetMethod(Config.Transformer).Invoke(transformer, new object[] { Data });
            Data = transformedData.ToString();
         }
        catch (Exception)
        {
            throw new Exception("Transformer Method not known.");
        }
    }

    public void Analyse()
    {
        try
        {
            object returnvalue = null;
            WorkShopAnalyzer analyzer = new ();
            if (Config.Analyzer.Split(';').Count() == 1)
            {
                returnvalue = typeof(WorkShopAnalyzer).GetMethod(Config.Analyzer.Split(';').First()).Invoke(analyzer, new object[] { Data });
            }
            else
            {
                string method = Config.Analyzer.Split(';')[0];
                string option = Config.Analyzer.Split(';')[1];
                returnvalue = typeof(WorkShopAnalyzer).GetMethod(method).Invoke(analyzer, new object[] {Data, option});
            }
            Analysed = returnvalue.ToString();
        }
        catch (Exception)
        {
            throw new Exception("Analyser Method not known.");
        }
    }

    public void Report()
    {
        StringBuilder report = new();

        report.AppendLine($"{DateTime.Now} Report für Analyzer {Config.Analyzer.Split(';')[0]} und Transformation {Config.Transformer}");
        report.AppendLine("Input:");
        report.AppendLine(Data);
        report.AppendLine("Analyse:");
        report.AppendLine(Analysed);

        if (Config.Reporter == "Console")
        {
            Console.Write(report.ToString());
        }

        if (Config.Reporter.StartsWith("File"))
        {
            string fileName = Config.Reporter.Split(';')[1];
            File.WriteAllText(fileName, report.ToString());
        }

    }
}


