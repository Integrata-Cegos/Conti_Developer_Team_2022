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

    public class FileReader: Reader
    {
        private string FileName;
        public FileReader(string fileName)
        {
            this.FileName = fileName;
        }       
        public string Read()
        {
            return File.ReadAllText(this.FileName);
        }
    }
}