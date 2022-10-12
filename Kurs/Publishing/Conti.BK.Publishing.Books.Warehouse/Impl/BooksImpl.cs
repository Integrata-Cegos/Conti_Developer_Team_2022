using Conti.BK.IsbnGenerator.API;
using System.Collections.Generic;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using Conti.BK.Store.API;
using Conti.BK.Books.API;
//using Conti.BK.Publishing.Books.Warehouse.Entities;
using Microsoft.EntityFrameworkCore;
namespace Conti.BK.Books.Impl
{

    public class BooksService : IBooksService
    {
        Conti.BK.Publishing.Books.Warehouse.Entities.publishingContext _context;
        public BooksService(IIsbnService isbnService, IStoreService storeService){
            this._isbnService = isbnService;
            this._context = new Conti.BK.Publishing.Books.Warehouse.Entities.publishingContext();
        }
        public BooksService(IIsbnService isbnService){
            this._isbnService = isbnService;
         this._context = new Conti.BK.Publishing.Books.Warehouse.Entities.publishingContext();
        }
        private IIsbnService _isbnService;

        //private Dictionary<Isbn, Book> _books = new Dictionary<Isbn, Book>();
        public Isbn CreateBook(string title, int pages, double price, Dictionary<string, Object> options)
        {
            if (title == null)
            {
                throw new ArgumentException("null title");
            }
            if (pages <= 0 )
            {
                throw new ArgumentException("invalid pages");
            }
            if (price < 0 )
            {
                throw new ArgumentException("invalid price");
            }
            if (options == null)
            {
                throw new ArgumentException("null options");
            }
            bool available = false;
            Isbn isbn = this._isbnService.Next();
            Book newBook;
            try
            {
                string? topic = options["topic"].ToString();
                newBook = new SpecialistBook(isbn, title, pages, price, available, topic!);
            }
            catch (Exception)
            {
                try
                {
                    string? subject = options["subject"].ToString();
                    int year = (int)options["year"];
                    newBook = new SchoolBook(isbn, title, pages, price, available, year, subject!);
                }
                catch (Exception)
                {
                    newBook = new Book(isbn, title, pages, price, available);
                }
            }
            this._context.Books.Add(newBook);
            //this._books.Add(isbn, newBook);
            return isbn;
        }
        public void UpdateBook(Book book)
        {
            _context.Books.Remove(book);
            _context.Books.Add(book);
        }
        public Book FindBookByIsbn(Isbn isbn)
        {
           // Book book = this._books[isbn];
            Book book = this._context.Books.Single(x => x.Isbn == isbn.ToString());
            this.SetAvailability(book);
            return book;
        }
        public void DeleteBookByIsbn(Isbn isbn)
        {
            this._context.Books.Remove(this._context.Books.Single(x=>x.Isbn == isbn.ToString()));
        }

        public List<Book> FindBooksByTitle(string title)
        {
            var bookList = this._context.Books.Where(x=>x.Title.Contains(title)).ToList().ConvertAll(book => SetAvailability(book));
            return bookList;
            //var bookList = this._books.Values.ToList();
            //return bookList.FindAll(book => book.Title.Equals(title)).ConvertAll(book => SetAvailability(book));
        }
        public List<Book> FindBooksByPriceRange(double minPrice, double maxPrice)
        {
            var bookList = this._context.Books.Where(x=>x.Price > minPrice && x.Price < maxPrice).ToList();
            return bookList;
           // var bookList = this._books.Values.ToList();
           // return bookList.FindAll(book => book.Price > minPrice && book.Price < maxPrice).ConvertAll(this.SetAvailability);
        }

        private Book SetAvailability(Book book)
        {
            //int stockForIsbn = this._storeService.GetStock("books", book.Isbn);
            int stockForIsbn = GetStockFromWebApi("books", book.Isbn);
            if (stockForIsbn > 0)
            {
                book.Available = true;
            }
            else
            {
                book.Available = false;
            }
            return book;
        }
private readonly HttpClient client = new HttpClient();
        private int GetStockFromWebApi(string cat, Isbn isbn)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("plain/text"));
            client.DefaultRequestHeaders.Add("cat",cat);
            client.DefaultRequestHeaders.Add("isbn",((Isbn)isbn).IsbnString);

            var booksPromise =  client.GetStreamAsync("http://localhost:5213/api/Stock/GetStock");
            var data = booksPromise.Result;
            var booksListPromise = JsonSerializer.DeserializeAsync<int>(data);
            Console.WriteLine(((Isbn)isbn).IsbnString + "   "+booksListPromise.Result);
            return booksListPromise.Result;
  
        }
    }

}