using Conti.Tom.Publishing.Books.IsbnGenerator;
using Conti.Tom.Publishing.Books.IsbnGenerator.Models;
using Conti.Tom.Publishing.Books.Warehouse.Models;

namespace Conti.Tom.Publishing.Application
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                TestBooksService();
                //TestPublisher();
                Console.ReadKey();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        public static void TestBooksService()
        {
            var booksService = ApplicationContext.IBooksService();
            Dictionary<string, Object> empty = new Dictionary<string, Object>();
            Dictionary<string, Object> school = new Dictionary<string, Object>();
            school.Add("year", 10);
            school.Add("subject", "sports");
            Dictionary<string, Object> specialist = new Dictionary<string, Object>();
            specialist.Add("topic", "gardening");

            Console.WriteLine(booksService.CreateBook("Title1", 120, 29.99, empty).Info());
            Console.WriteLine(booksService.CreateBook("Title1", 1309, 19.99, school).Info());
            Console.WriteLine(booksService.CreateBook("Title2", 160, 9.99, specialist).Info());
            Console.WriteLine(booksService.CreateBook("Title3", 100, 7.99, specialist).Info());
            Console.WriteLine(booksService.CreateBook("Title4", 1990, 4.99, specialist).Info());
            //Console.WriteLine(booksService.FindBookByIsbn(new ISBN(4, 5, 6, 7)).Info());
            //Console.WriteLine(booksService.FindBookByIsbn(new ISBN(1, 2, 3, 3)).Info());
            var result = booksService.FindBooksByTitle("Title2");
            var result2 = booksService.FindBooksByPriceRange(2, 20);
            result2.Sort();
            var result3 = booksService.FindBooksByTitle("Title1");
            result3.Sort((b1, b2) => b1.Pages.CompareTo(b2.Pages));
            var titles = result3.ConvertAll(b1 => b1.ISBN);
        }

        public static void TestPublisher()
        {
            Publisher springer = new("Springer Verlag");
            springer.AddBook(CreateDefaultBook());
            springer.AddBook(CreateDefaultSpecialistBook());
            Book three = CreateDefaultSchoolBook();
            springer.AddBook(three);
            foreach (var item in springer.GetAllBooks())
            {
                Console.WriteLine($"{item}");
            }
            springer.RemoveBook(three);
            foreach (var item in springer.GetAllBooks())
            {
                Console.WriteLine($"{item}");
            }
        }

        public static Book CreateDefaultBook()
        {
            return new Book(new ISBN(1, 2, 3, 4), "Title 1", 100, 19.99, true);
        }
        public static SchoolBook CreateDefaultSchoolBook()
        {
            return new SchoolBook(new ISBN(1, 2, 3, 5), "Title 2", 120, 29.99, true, 2010, "physics");
        }
        public static SpecialistBook CreateDefaultSpecialistBook()
        {
            return new SpecialistBook(new ISBN(1, 2, 3, 6), "Title 3", 200, 9.99, true, "gardening");
        }

    }

}
