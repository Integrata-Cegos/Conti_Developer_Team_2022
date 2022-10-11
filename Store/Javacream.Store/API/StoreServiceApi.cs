namespace Javacream.Store.API{

    public interface IStoreService{
        public int GetStock(string category, Object item);
        public void SetStock(string category, Object item, int stock);
        public List<string> GetCategories();
        public int GetNumberOfItemsFor(string category);
        public Dictionary<string, int> GetNumberOfItemsForCategories();
        public void DeleteItemFromStore(string category, object item);
        public void DeleteCategory(string category);
    }
}