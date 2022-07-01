using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;
public class Application{

    private static readonly HttpClient client = new HttpClient();
    public static async Task Main(string[] args){
        await new Application().callWs();
    }  

    public async Task callWs()
    {
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

    var stringTask = client.GetStringAsync("http://h2908727.stratoserver.net:8080/api/books");

    var msg = await stringTask;
    Console.Write(msg);

    var streamTask = client.GetStreamAsync("http://h2908727.stratoserver.net:8080/api/books");
    var books = await JsonSerializer.DeserializeAsync<List<Book>>(await streamTask);
    books.ForEach(book => Console.WriteLine(book.isbn));
    }


}

class Book{
    public string isbn {get;set;}
}