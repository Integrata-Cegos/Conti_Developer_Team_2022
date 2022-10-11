using Javacream.IsbnGenerator.API;
using Javacream.Store.API;
using Javacream.Books.API;
using Javacream.Books.Warehouse.Entities;
namespace Javacream.Books.Impl
{

    public class BooksService : IBooksService
    {
        public BooksService(IIsbnService isbnService, IStoreService storeService){
            this._isbnService = isbnService;
            this._storeService = storeService; 
        }
        private IIsbnService _isbnService;
        private IStoreService _storeService;
        public Isbn CreateBook(string title, int pages, double price, Dictionary<string, Object> options)
        {
            var context = new publishingContext();
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
            var bookEntity = new Javacream.Publishing.Books.Warehouse.Entities.Book();
            try
            {
                string? topic = options["topic"].ToString();
                bookEntity.Isbn = isbn.ToString();
                bookEntity.Title = title;
                bookEntity.Price = price;
                bookEntity.Pages = pages;
                bookEntity.Available = available;
                bookEntity.Topic = topic;
                bookEntity.Discriminator = "specialist";
            }
            catch (Exception)
            {
                try
                {
                    string? subject = options["subject"].ToString();
                    int year = (int)options["year"];
                    bookEntity.Isbn = isbn.ToString();
                    bookEntity.Title = title;
                    bookEntity.Price = price;
                    bookEntity.Pages = pages;
                    bookEntity.Available = available;
                    bookEntity.Subject = subject;
                    bookEntity.Year = year;
                    bookEntity.Discriminator = "school";
                }
                catch (Exception)
                {
                    bookEntity.Isbn = isbn.ToString();
                    bookEntity.Title = title;
                    bookEntity.Price = price;
                    bookEntity.Pages = pages;
                    bookEntity.Available = available;
                }
            }
            context.Books.Add(bookEntity);
            context.SaveChanges();
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
            int stockForIsbn = this._storeService.GetStock("books", book.Isbn);
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