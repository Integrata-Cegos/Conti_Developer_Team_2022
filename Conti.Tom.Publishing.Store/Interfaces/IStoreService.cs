namespace Conti.Tom.Publishing.Store
{
    public interface IStoreService
    {
        int GetStock(string category, object item);
        void SetStock(string category, Object item, int stock);
    }
}