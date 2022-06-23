using Conti.BK.IsbnGenerator.API;
using Conti.BK.IsbnGenerator.Impl;
using Conti.BK.Store.API;
using Conti.BK.Store.Impl;
using Conti.BK.Books.API;
using Conti.BK.Books.Impl;

public static class ApplicationContext{
    static ApplicationContext(){
        _isbnService = new RandomIsbnService();
        _storeService = new StoreService();
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