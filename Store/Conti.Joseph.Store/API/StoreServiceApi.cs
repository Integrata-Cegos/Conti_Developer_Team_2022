namespace Conti.Joseph.Store.API{

    public interface IStoreService{
        public int GetStock(string category, Object item);
    }
}