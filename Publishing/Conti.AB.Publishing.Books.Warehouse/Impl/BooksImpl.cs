using Conti.AB.IsbnGenerator.API;
using Conti.AB.Books.API;
using Conti.AB.Store.API;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Conti.AB.Books.Impl
{

    public class BooksService : IBooksService
    {
        private readonly HttpClient client = new HttpClient();

        public BooksService(IIsbnService isbnService, IStoreService storeService){
            this._isbnService = isbnService;
            this._storeService = storeService; 
        }

        private IIsbnService _isbnService;
        private IStoreService _storeService;
        private Dictionary<Isbn, Book> _books = new Dictionary<Isbn, Book>();
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
            this._books.Add(isbn, newBook);
            return isbn;
        }

        public Book FindBookByIsbn(Isbn isbn)
        {
            Book book = this._books[isbn];
            this.SetAvailability(book);
            return book;
        }
        public void DeleteBookByIsbn(Isbn isbn)
        {
            this._books.Remove(isbn);
        }

        public List<Book> FindBooksByTitle(string title)
        {
            var bookList = this._books.Values.ToList();
            return bookList.FindAll(book => book.Title.Equals(title)).ConvertAll(book => SetAvailability(book));
        }
        public List<Book> FindBooksByPriceRange(double minPrice, double maxPrice)
        {
            var bookList = this._books.Values.ToList();
            return bookList.FindAll(book => book.Price > minPrice && book.Price < maxPrice).ConvertAll(this.SetAvailability);
        }

        public void UpdateBook(Book book)
        {
            _books.Remove(book.Isbn);
            _books.Add(book.Isbn, book);
        }

        private Book SetAvailability(Book book)
        {
            Task<String> stockPromise = client.GetStringAsync($"http://localhost:5095/api/store/path/books/{book.Isbn}");
            int stockForIsbn = Int32.Parse(stockPromise.Result);
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
    }

}