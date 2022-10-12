using WordProcessor.Impl;

class Program{
    static void Main(string[] args)
    {
        Configuration configuration = new Configuration("c:\\_training\\" + args[0]);
        WordProcessorImpl wordProcessor = new WordProcessorImpl(configuration.Reader!, configuration.Transformer!, configuration.Analyzer!, configuration.Reporter!);
        wordProcessor.Process();

    }
}
