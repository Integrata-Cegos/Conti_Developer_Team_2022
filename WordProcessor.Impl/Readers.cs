using WordProcessor.Api;

namespace WordProcessor.Impl.Readers{

    public class ConsoleReader: Reader
    {
        public string Read()
        {
            Console.WriteLine("Enter text, empty line to finish:");
            string result = "";
            string? s = "";
            while((s = Console.ReadLine()) != null)
            {
                result += s;
            } 
            return result;
        }
    }
}