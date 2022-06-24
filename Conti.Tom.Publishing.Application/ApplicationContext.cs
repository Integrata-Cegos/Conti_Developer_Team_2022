using Conti.Tom.Publishing.Books.Warehouse;
using Conti.Tom.Publishing.Books.IsbnGenerator.Services;
using Conti.Tom.Publishing.Books.IsbnGenerator.Models;
using Conti.Tom.Publishing.Store;
using Conti.Tom.Publishing.Service;
using Conti.Tom.Publishing.Books.IsbnGenerator.Interfaces;
using Conti.Tom.Publishing.Books.Warehouse.Interfaces;
using Conti.Tom.Publishing.Books.Warehouse.Services;

namespace Conti.Tom.Publishing.Application
{
    public static class ApplicationContext
    {
        private static IISBNService _ISBNService;
        private static IStoreService _StoreService;
        private static IBooksService _BooksService;
        private static IConfigurationService _ConfigurationService;

        static ApplicationContext()
        {
            _ConfigurationService = new ConfigurationService();
            _ISBNService = new RandomISBNService();
            _ISBNService.Prefix = _ConfigurationService.GetConfiguration("isbn.prefix");
            _ISBNService.CountryCode = _ConfigurationService.GetConfiguration("isbn.countryCode");
            _StoreService = new StoreService();
            _BooksService = new BooksService(_ISBNService, _StoreService);
            _StoreService.SetStock("books", new ISBN(4, 5, 6, 7), 100);
        }

        public static IISBNService IISBNService() { return _ISBNService; }
        public static IStoreService IStoreService() { return _StoreService; }
        public static IBooksService IBooksService() { return _BooksService; }

    }
}
