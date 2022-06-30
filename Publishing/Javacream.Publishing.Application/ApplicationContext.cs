using Javacream.IsbnGenerator.API;
using Javacream.IsbnGenerator.Impl;
using Javacream.Store.API;
using Javacream.Store.Impl;
using Javacream.Books.API;
using Javacream.Books.Impl;
using Javacream.Util;
public static class ApplicationContext{
    static ApplicationContext(){
        RandomIsbnService randomIsbnService = new RandomIsbnService();
        randomIsbnService.Prefix = Configuration.GetConfiguration("isbn.prefix");
        randomIsbnService.CountryCode = Configuration.GetConfiguration("isbn.countryCode");
        _isbnService = randomIsbnService;
        _storeService = new StoreService();
        _storeService.SetStock("books", new Isbn(4,5,6,7), 100);
        _storeService.SetStock("books", new Isbn(4,5,6,8), 10);
        _booksService = new BooksService(_isbnService, _storeService);
    }
    private static IIsbnService _isbnService;
    public static IIsbnService IIsbnService(){
        return _isbnService;
    }

    private static IStoreService _storeService;

    public static IStoreService IStoreService(){
        return _storeService;
    }  
    private static IBooksService _booksService;

    public static IBooksService IBooksService(){
        return _booksService;
    }  

}