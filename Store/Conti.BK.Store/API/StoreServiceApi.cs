namespace Conti.BK.Store.API{

    public interface IStoreService{
        public int GetStock(string category, Object item);
        public void SetStock(string category, Object item, int stock);
        public List<string> GetAllCat();
        public int GetNumberOfItemsFor(string category);
        public List<KeyValuePair<string,int>> GetNumberOfItemsForCats();
        public void DeleteItem(string category, string item);
        public void DeleteCat(string category);
    }
}