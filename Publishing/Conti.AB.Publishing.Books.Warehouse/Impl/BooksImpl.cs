using Conti.AB.IsbnGenerator.API;
using Conti.AB.Books.API;
using Conti.AB.Store.API;
using Conti.AB.Publishing.Books.Warehouse.entities;

namespace Conti.AB.Books.Impl
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
            //Book newBook;
            var bookEntity = new Conti.AB.Publishing.Books.Warehouse.entities.Book();
            try
            {
                string? topic = options["topic"].ToString();
                //newBook = new SpecialistBook(isbn, title, pages, price, available, topic!);
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
                    //newBook = new SchoolBook(isbn, title, pages, price, available, year, subject!);
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
                    //newBook = new Book(isbn, title, pages, price, available);
                    bookEntity.Isbn = isbn.ToString();
                    bookEntity.Title = title;
                    bookEntity.Price = price;
                    bookEntity.Pages = pages;
                    bookEntity.Available = available;
                }
            }
            //this._books.Add(isbn, newBook);
            context.Books.Add(bookEntity);
            context.SaveChanges();
            return isbn;
        }

        public Conti.AB.Books.API.Book FindBookByIsbn(Isbn isbn)
        {
            //Book book = this._books[isbn];
            string isbnAsString = isbn.ToString();
            Conti.AB.Books.API.Book book = assemble(context.Books.Single(book => book.Isbn == isbnAsString));
            this.SetAvailability(book);
            return book;
        }
        public void DeleteBookByIsbn(Isbn isbn)
        {
            //this._books.Remove(isbn);
            string isbnAsString = isbn.ToString();
            context.Remove(context.Books.Where(book => book.Isbn == isbnAsString));
        }

        public List<Conti.AB.Books.API.Book> FindBooksByTitle(string title)
        {
            //var bookList = this._books.Values.ToList();
            //return bookList.FindAll(book => book.Title.Equals(title)).ConvertAll(book => SetAvailability(book));
            return assemble(context.Books.Where(book => book.Title == title).ToList());
        }
        public List<Conti.AB.Books.API.Book> FindBooksByPriceRange(double minPrice, double maxPrice)
        {
            //var bookList = this._books.Values.ToList();
            //return bookList.FindAll(book => book.Price > minPrice && book.Price < maxPrice).ConvertAll(this.SetAvailability);
            return assemble(context.Books.Where(book => book.Price > minPrice && book.Price < maxPrice).ToList());
        }

        public void UpdateBook(Conti.AB.Books.API.Book book)
        {
            //_books.Remove(book.Isbn);
            //_books.Add(book.Isbn, book);
            context.Books.Add(assemble(book));
            context.SaveChanges();
        }

        private Conti.AB.Books.API.Book SetAvailability(Conti.AB.Books.API.Book book)
        {
            //Task<String> stockPromise = client.GetStringAsync($"http://localhost:5095/api/store/path/books/{book.Isbn}");
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

        private Conti.AB.Publishing.Books.Warehouse.entities.Book assemble(Conti.AB.Books.API.Book b)
        {
            var bookEntity = new Conti.AB.Publishing.Books.Warehouse.entities.Book();
            bookEntity.Isbn = b.Isbn.ToString();
            bookEntity.Title = b.Title;
            bookEntity.Price = b.Price;
            bookEntity.Pages = b.Pages;
            //bookEntity.Available = b.Available;
            return bookEntity;
        }

        private Conti.AB.Books.API.Book assemble(Conti.AB.Publishing.Books.Warehouse.entities.Book b)
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
            Isbn isbn = new Isbn(prefix, countryCode, part1, part2, part3, part3);
            var book = new Conti.AB.Books.API.Book(isbn, b.Title, (int)b.Pages, (double)b.Price, false);
            
            return book;
        }

        private List<Conti.AB.Books.API.Book> assemble(List<Conti.AB.Publishing.Books.Warehouse.entities.Book> books)
        {
            return books.Select(b => assemble(b)).ToList();
        }
    }

}