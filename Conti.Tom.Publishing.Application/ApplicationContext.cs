using Conti.Tom.Publishing.Books.Warehouse;
using Conti.Tom.Publishing.Books.IsbnGenerator;
using Conti.Tom.Publishing.Store;

namespace Conti.Tom.Publishing.Application
{
    public static class ApplicationContext
    {
        private static IISBNService _ISBNService;
        private static IStoreService _StoreService;
        private static IBooksService _BooksService;

        static ApplicationContext()
        {
            _ISBNService = new ISBNService();
            _StoreService = new StoreService();
            _BooksService = new BooksService(_ISBNService, _StoreService);
            _StoreService.SetStock("books", new ISBN(4, 5, 6, 7), 100);
        }

        public static IISBNService IISBNService() { return _ISBNService; }
        public static IStoreService IStoreService() { return _StoreService; }
        public static IBooksService IBooksService() { return _BooksService; }

    }
}
