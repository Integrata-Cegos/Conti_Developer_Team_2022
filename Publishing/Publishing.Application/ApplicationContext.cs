using Conti.Joseph.IsbnGenerator.API;
using Conti.Joseph.IsbnGenerator.Impl;
using Conti.Joseph.Store.API;
using Conti.Joseph.Store.Impl;
using Conti.Joseph.Books.API;
using Conti.Joseph.Books.Impl;

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