
using System.Net.Http;
using System.Net.Http.Headers;
public class Application
{
    private readonly HttpClient client = new HttpClient();
    public static void Main(string[] args)
    {
        Console.WriteLine("starting main...");
        new Application().CallWebService();
        Console.WriteLine("finished main");
    }

    private void CallWebService()
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var result = client.GetStringAsync("http://h2908727.stratoserver.net:8080/api/books");
        Console.WriteLine(result);
    }
}