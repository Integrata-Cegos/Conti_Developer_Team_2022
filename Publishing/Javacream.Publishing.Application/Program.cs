using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;

public class Application
{
    private readonly HttpClient client = new HttpClient();
    public static async Task Main(string[] args)
    {
        Console.WriteLine("starting main...");
        await new Application().callWebService();
        Console.WriteLine("finished main");
    }

    private async Task callWebService()
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        string result = await client.GetStringAsync("http://h2908727.stratoserver.net:8080/api/books");
        Console.WriteLine(result);

        var data = await client.GetStreamAsync("http://h2908727.stratoserver.net:8080/api/books");
        var booksList = await JsonSerializer.DeserializeAsync<List<Book>>(data);
        booksList.ForEach(book => Console.WriteLine(book.isbn));

    }

    class Book{
        public string isbn {get; set;}
        public string title {get; set;}
    }
}