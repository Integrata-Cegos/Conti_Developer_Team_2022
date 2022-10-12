// See https://aka.ms/new-console-template for more information

using WorkShopProcessor;

var arguments = Environment.GetCommandLineArgs();

if (Environment.GetCommandLineArgs().Count() != 2)
{
    Console.WriteLine("Please specify configuration File");
    Environment.Exit(1);
}
else
{
        WordProcessor processor = new(new WorkShopReaderConfig(Environment.GetCommandLineArgs()[1]));
        processor.Read();
        processor.Transform();
        processor.Analyse();
        processor.Report();
}




