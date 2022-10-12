using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopProcessor;
public class WorkShopAnalyzer : IWorkShopAnalyzer
{
    public int WordCount(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("No Argument given");
        }

        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count();
    }

    public int WordStartsWith(string input, string startString)
    {
        if (input == null || startString == null)
        {
            throw new ArgumentNullException("No Argument given");
        }
        List<string> workingList = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        return workingList.Where(x => x.StartsWith(startString)).Count();
    }

    public int WordsContains(string input, string containString)
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
        return returnvalue;
    }

    public string LetterCount(string input)
    {
        StringBuilder returnvalue = new();
        if (input == null)
        {
            throw new ArgumentNullException("No Argument given");
        }
        IEnumerable<string> collection = input.ToUpper().GroupBy(x => x).Where(x => x.Key != ' ').Select(x => $"Anzahl Wörter, die mit ‘{x.Key}’ beginnen: {x.Count()}");

        foreach (var item in collection)
        {
            returnvalue.AppendLine(item);
        }
        return returnvalue.ToString();
    }

}
