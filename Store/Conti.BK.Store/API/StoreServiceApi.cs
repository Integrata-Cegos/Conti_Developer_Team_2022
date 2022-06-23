namespace Conti.BK.Store.API{

    public interface IStoreService{
        public int GetStock(string category, Object item);
    }
}