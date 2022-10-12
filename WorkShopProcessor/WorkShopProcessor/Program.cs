using WorkShopProcessor;

var arguments = Environment.GetCommandLineArgs();
#if !DEBUG
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
#else

WordProcessor processor = new(new WorkShopReaderConfig("SampleConfig2.cfg"));
processor.Read();
processor.Transform();
processor.Analyse();
processor.Report();

Console.ReadKey();


#endif