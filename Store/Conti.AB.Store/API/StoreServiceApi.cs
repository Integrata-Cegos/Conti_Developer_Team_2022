namespace Conti.AB.Store.API{

    public interface IStoreService{
        public int GetStock(string category, Object item);
        public void SetStock(string category, Object item, int stock);
    }
}