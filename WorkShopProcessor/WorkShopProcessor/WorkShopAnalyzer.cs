using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopProcessor;
public class WorkShopAnalyzer : IWorkShopAnalyzer
{
    public string WordCount(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("No Argument given");
        }

        return $"{input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count()} Wörter vorhanden.";
    }

    public string WordStartsWith(string input, string startString)
    {
        int count = 0;
        if (input == null || startString == null)
        {
            throw new ArgumentNullException("No Argument given");
        }
        List<string> workingList = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        count =  workingList.Where(x => x.StartsWith(startString)).Count();
        return $"{count} Wörter beginnen mit {startString}";
    }

    public string WordContains(string input, string containString)
    {
        int returnvalue = 0;
        if (input == null || containString == null)
        {
            throw new ArgumentNullException("No Argument given");
        }
        List<string> workingList = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        foreach (var item in workingList)
        {
            if (item.Contains(containString))
            {
                returnvalue++;
            }
        }
        return $"{returnvalue} Wörter enthalten {containString}";
    }

    public string LetterCount(string input)
    {
        StringBuilder returnvalue = new();
        if (input == null)
        {
            throw new ArgumentNullException("No Argument given");
        }
        IEnumerable<string> collection = input.ToUpper().GroupBy(x => x).Where(x => x.Key != ' ').Select(x => $"{x.Key} vorhanden: {x.Count()}");

        foreach (var item in collection)
        {
            returnvalue.AppendLine(item);
        }
        return returnvalue.ToString();
    }

}
