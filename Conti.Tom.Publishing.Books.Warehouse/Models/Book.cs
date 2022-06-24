using Conti.Tom.Publishing.Books.IsbnGenerator.Models;

namespace Conti.Tom.Publishing.Books.Warehouse.Models
{
    public class Book : IComparable<Book>
    {
        public ISBN ISBN { get; }

        private string _title;
        public string Title
        {
            get { return _title; }
            private set
            {
                if (value.Length > 1)
                {
                    _title = value;
                }
                else
                {
                    //Title = "";
                    throw new ArgumentException("Title has to be at least 2 Characters long....");
                }

            }
        }

        private int _pages;
        public int Pages
        {
            get { return _pages; }
            set
            {
                if (value != 0)
                {
                    _pages = value;
                }
                else
                {
                    throw new ArgumentException("Pages must be greater than 0....");
                }

            }
        }

        private double _price;

        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be greater or exactly 0....");
                }
                else
                {
                    _price = value;
                }
            }
        }

        public bool Available { get; set; }

        public virtual string Info()
        {
            return $"ISBN:{ISBN} / Title:{Title} / Pages:{Pages} / Price:{Price}Euro / Available:{Available}";
        }

        public override string ToString()
        {
            return Info();
        }

        public int CompareTo(Book? book)
        {
            if (book != null)
            {
                return Title.CompareTo(book.Title);
            }
            else
            {
                throw new Exception("Unable to Compare Books");
            }
        }

        public Book(ISBN isbn, string title, int pages, double price, bool available)
        {
            ISBN = isbn;
            Title = title;
            Pages = pages;
            Price = price;
            Available = available;
        }

    }
}
