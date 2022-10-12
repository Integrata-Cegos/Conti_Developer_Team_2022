using Conti.BK.IsbnGenerator.API;
using Conti.BK.IsbnGenerator.Impl;
using Conti.BK.Store.API;
using Conti.BK.Store.Impl;
using Conti.BK.Books.API;
using Conti.BK.Books.Impl;
using Conti.BK.Util;

public static class ApplicationContext{
    static ApplicationContext(){
        RandomIsbnService randomIsbnService = new RandomIsbnService();
        randomIsbnService.Prefix = Configuration.GetConfiguration("isbn.prefix");
        randomIsbnService.CountryCode = Configuration.GetConfiguration("isbn.countryCode");
        _isbnService = randomIsbnService;
        _storeService = new DatabaseStoreService();
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