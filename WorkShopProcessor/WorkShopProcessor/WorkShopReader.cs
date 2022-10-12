using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShopProcessor;
public class WorkShopReader : IWorkShopReader
{
	public string ConsoleRead()
	{
		try
		{
			Console.WriteLine("Please enter Text to be analysed:");
			return Console.ReadLine();
		}
		catch (Exception)
		{
			throw;
		}
	}

	public string FileRead(string fileName)
	{
		if (fileName == null)
		{
			throw new ArgumentNullException("No Argument given");
		}
		try
		{
			return File.ReadAllText(fileName);
		}
		catch (FileNotFoundException e)
		{
			Console.WriteLine("Input File not Found!");
			Environment.Exit(-1);
		}
		catch (Exception)
		{
			throw;
		}
		return null;
	}
}
