namespace Conti.AB.Store.API{

    public interface IStoreService{
        public int GetStock(string category, Object item);
        public void SetStock(string category, Object item, int stock);
        public List<string> GetCategories();
        public int GetNumberOfItemsFor (string category);
        public List<string> GetNumberOfItemsForCategories();
        public void DeleteItem (string category, Object item);
        public void DeleteCategory (string category);
    }
}