using Javacream.IsbnGenerator.API;
using Javacream.Store.API;
using Javacream.Books.API;
using Javacream.Books.Warehouse.Entities;
namespace Javacream.Books.Impl
{

    public class BooksService : IBooksService
    {
        private publishingContext context = new publishingContext();
        public BooksService(IIsbnService isbnService, IStoreService storeService){
            this._isbnService = isbnService;
            this._storeService = storeService; 
        }
        private IIsbnService _isbnService;
        private IStoreService _storeService;
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
            string isbnAsString = isbn.ToString();
            Book book = assemble(context.Books.Single(b => b.Isbn == isbnAsString));
            this.SetAvailability(book);
            return book;
        }
        public void DeleteBookByIsbn(Isbn isbn)
        {
            string isbnAsString = isbn.ToString();
            context.Books.Remove(context.Books.Single(b => b.Isbn == isbnAsString));
        }

        public List<Book> FindBooksByTitle(string title)
        {
            return context.Books.Where(book => book.Title = title).ToList();
        }
        public List<Book> FindBooksByPriceRange(double minPrice, double maxPrice)
        {
            return context.Books.Where(book => book.Price > minPrice && book.Price < maxPrice).ToList();
        }

        public void UpdateBook(Book book)
        {
            context.Books.Add(assemble(book));
            context.SaveChanges();
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

        private Javacream.Publishing.Books.Warehouse.Entities.Book assemble(Book b)
        {
            var bookEntity = new Javacream.Publishing.Books.Warehouse.Entities.Book();
            bookEntity.Isbn = b.Isbn.ToString();
            bookEntity.Title = b.Title;
            bookEntity.Pages = b.Pages;
            bookEntity.Price = b.Price;
            return bookEntity;

        }
        private Book assemble(Javacream.Publishing.Books.Warehouse.Entities.Book b)
        {
            string isbnAsString = b.Isbn;
            string[] splitted = isbnAsString.Split(":");
            string prefix = splitted[0];
            string[] partsAndCountryCode = splitted[1].Split("-");
            int part1 = Int32.Parse(partsAndCountryCode[0]);
            int part2 = Int32.Parse(partsAndCountryCode[1]);
            int part3 = Int32.Parse(partsAndCountryCode[2]);
            int part4 = Int32.Parse(partsAndCountryCode[3]);
            string countryCode = partsAndCountryCode[4];
            Isbn isbn = new Isbn(prefix, countryCode, part1, part2, part3, part4);
            var book = new Book(isbn, b.Title, (int)b.Pages, (double)b.Price, false);
            return book;

        }
 
        private List<Book> assemble(List<Javacream.Publishing.Books.Warehouse.Entities.Book> books)
        {
            return books.Select(b => assemble(b)).ToList();

        }
 
    }

}