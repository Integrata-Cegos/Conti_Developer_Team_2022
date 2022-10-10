using System.Net.Http;
using System.Net.Http.Headers;

public class Application
{
    private readonly HttpClient client = new HttpClient();
    public static void Main(string[] args)
    {
        Console.WriteLine("Starting Main");
        new Application().callWebService();
    }

    private void callWebService()
    {
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("apllication/jason"));
        client.DefaultRequestHeaders.Accept.Clear();
        var result = client.GetStreamAsync("http://h2908727.stratoserver.net:8080/api/books");
        Console.WriteLine(result);
    }

}
