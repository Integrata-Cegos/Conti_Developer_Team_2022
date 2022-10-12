using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WorkShopProcessor;
public class WorkShopTransformer : IWorkShopTransformer
{
    public string ToUpper(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("No Argument given");
        }
        return input.ToUpper();
    }

    public string ToLower(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("No Argument given");
        }
        return input.ToLower();
    }

    public string RemoveWhiteSpaces(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException("No Argument given");
        }
        return Regex.Replace(input, @"\s+", "");
    }

}
