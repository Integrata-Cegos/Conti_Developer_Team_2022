using System.Net.Http;
using System.Net.Http.Headers;


public class Application
{
    private readonly HttpClient client = new HttpClient();
    public static void Main(string[] args)
    {
        Console.WriteLine("starting main...");
        new Application().callWebService();
        Console.WriteLine("finished main");
    }

    private void callWebService()
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        Task<String> resultPromise = client.GetStringAsync("http://h2908727.stratoserver.net:8080/api/books");
        Console.WriteLine(resultPromise.Result);

    }
}