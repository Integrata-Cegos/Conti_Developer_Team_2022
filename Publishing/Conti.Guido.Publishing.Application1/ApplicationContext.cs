using Conti.Guido.IsbnGenerator.API;
using Conti.Guido.IsbnGenerator.Impl;
using Conti.Guido.Store.API;
using Conti.Guido.Store.Impl;
using Conti.Guido.Books.API;
using Conti.Guido.Books.Impl;
using Conti.Guido.Util;
public static class ApplicationContext{
    static ApplicationContext(){
        RandomIsbnService randomIsbnService = new RandomIsbnService();
        randomIsbnService.Prefix = Configuration.GetConfiguration("isbn.prefix");
        randomIsbnService.CountryCode = Configuration.GetConfiguration("isbn.counryCode");
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