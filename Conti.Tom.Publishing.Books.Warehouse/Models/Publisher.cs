namespace Conti.Tom.Publishing.Books.Warehouse.Models
{
    public class Publisher
    {
        public Publisher(string name)
        {
            Name = name;
        }
        public string Name { get; }

        private List<Book> _books = new List<Book>();

        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (_books.Contains(book))
                _books.Remove(book);
        }

        public void ClearBooks()
        {
            _books.Clear();
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }
    }
}
