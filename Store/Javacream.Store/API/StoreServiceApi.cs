namespace Javacream.Store.API{

    public interface IStoreService{
        public int GetStock(string category, Object item);
        public void SetStock(string category, Object item, int stock);
        public List<String> GetCategories();
        public int GetNumberOfItemsFor(string category);
        public List<string> GetNumberOfItemsForCategories();
        public void DeleteItem(string category, Object item);
        public void DeleteCategory(string category);

    }
}