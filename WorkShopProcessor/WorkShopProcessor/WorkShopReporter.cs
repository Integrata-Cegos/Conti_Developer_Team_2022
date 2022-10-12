using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopProcessor;
public class WorkShopReporter : IWorkShopReporter
{
    public void ReportToConsole(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("No Argument given");
        }
        Console.WriteLine(input);
    }

    public void ReportToFile(string input, string fileName)
    {
        if (input == null || fileName == null)
        {
            throw new ArgumentNullException("No Argument given");
        }
        File.WriteAllText(fileName, input);
    }
}
