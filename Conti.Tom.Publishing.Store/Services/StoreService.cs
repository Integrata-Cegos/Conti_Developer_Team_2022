namespace Conti.Tom.Publishing.Store
{
    public class StoreService : IStoreService
    {
        class StoreEntry
        {
            public StoreEntry(string cat, Object item)
            {
                this._category = cat;
                this._item = item;
            }
            private string _category;
            private Object _item;

            public override int GetHashCode()
            {
                return _category.GetHashCode() + _item.GetHashCode();
            }

            public override bool Equals(object? obj)
            {
                if (obj != null)
                {
                    StoreEntry se = (StoreEntry)obj;
                    return se._item.Equals(this._item) && se._category.Equals(this._category);
                }
                else
                {
                    return false;
                }
            }
        }

        private Dictionary<StoreEntry, int> _stock;

        public StoreService()
        {
            _stock = new Dictionary<StoreEntry, int>();
        }

        public int GetStock(string category, Object item)
        {
            if (category == null || item == null)
            {
                throw new ArgumentException();
            }

            try
            {
                int stock = _stock[new StoreEntry(category, item)];
                return stock;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void SetStock(string category, Object item, int stock)
        {
            if (category == null || item == null || stock < 0)
            {
                throw new ArgumentException();
            }
            _stock[new StoreEntry(category, item)] = stock;
        }

        public void SetStockJC(string category, Object item, int stock)
        {
            if (category == null || item == null || stock < 0)
            {
                throw new ArgumentException();
            }
            StoreEntry entry = new StoreEntry(category, item);
            _stock.Remove(entry);
            _stock.Add(entry, stock);
        }
    }
}
