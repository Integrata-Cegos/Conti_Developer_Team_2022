using Conti.BK.Store.API;
using System.Data.Common;
using System.Data.SqlClient;

namespace Conti.BK.Store.Impl{
    public class DatabaseStoreService : IStoreService{
        private string _connectionString;
        public class StoreEntry{
            public StoreEntry(string cat, Object item){
                if (cat == null){
                    throw new ArgumentException("null category");
                }
                if (item == null){
                    throw new ArgumentException("null item");
                }
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
                if (obj != null){
                StoreEntry se = (StoreEntry) obj;
                return se._item.Equals(this._item) && se._category.Equals(this._category);
                }
                else{
                    return false;
                }
            }
        }
        public Dictionary<StoreEntry, int> _stock;
        DbProviderFactory dbProviderFactory;
        public DatabaseStoreService(){
         _stock = new Dictionary<StoreEntry, int>();
         _connectionString = "Data Source=h2908727.stratoserver.net;Initial Catalog=publishing;User ID=teilnehmer;Password=teilnehmer123!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        dbProviderFactory = SqlClientFactory.Instance;
        }

        public int GetStock(string category, Object item){
            int stock = 0;
            if(item == null || category == String.Empty || category == null){
                throw new ArgumentException("stock was null");
                return 0;
            }
            using(var connection = dbProviderFactory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open(); //erst jetzt wird physikalisch eine Netzwerkverbindung zur Datenbank aufgebaut

                DbCommand command = dbProviderFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select STOCK from STORE WHERE ITEM = @item AND CATEGORY = @cat";
                command.Parameters.Add(new SqlParameter("@cat",category));
                command.Parameters.Add(new SqlParameter("@item",item.ToString()));
                var reader = command.ExecuteReader();

                while(reader.Read()) //Lies die nächste Zeile der Treffermenge
                {
                    stock = (int)reader["STOCK"];
                }
            }
            //bool hasStock = _stock.TryGetValue(new StoreEntry(category, item), out stock);

                return stock;

        }
        

        public void SetStock(string category, Object item, int stock){
            if (stock < 0){
                throw new ArgumentException("stock was null");
            }
            StoreEntry entry = new StoreEntry(category, item);
            _stock.Remove(entry);
            _stock.Add(entry, stock);
            using(var connection = dbProviderFactory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open(); //erst jetzt wird physikalisch eine Netzwerkverbindung zur Datenbank aufgebaut

                DbCommand command = dbProviderFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE STORE SET STOCK = @stock WHERE CATEGORY = @cat AND ITEM = @item; IF @@ROWCOUNT = 0 BEGIN INSERT INTO STORE(CATEGORY,ITEM,STOCK) VALUES(@cat,@item,@stock); END;";
                command.Parameters.Add(new SqlParameter("@cat",category));
                command.Parameters.Add(new SqlParameter("@item",item.ToString()));
                command.Parameters.Add(new SqlParameter("@stock",stock));
                var reader = command.ExecuteNonQuery();

            }
        }
        public List<string> GetAllCat(){
            HashSet<string> res = new();
            using(var connection = dbProviderFactory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open(); //erst jetzt wird physikalisch eine Netzwerkverbindung zur Datenbank aufgebaut

                DbCommand command = dbProviderFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT DISTINCT CATEGORY FROM STORE";
                var reader = command.ExecuteReader();

                while(reader.Read()) //Lies die nächste Zeile der Treffermenge
                {
                    res.Add((string)reader["CATEGORY"]);
                }
            }
            return res.ToList();
        }
        public int GetNumberOfItemsFor(string cat){
            int res = 0;
            using(var connection = dbProviderFactory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open(); //erst jetzt wird physikalisch eine Netzwerkverbindung zur Datenbank aufgebaut

                DbCommand command = dbProviderFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(ITEM) FROM STORE WHERE CATEGORY = @cat";
                command.Parameters.Add(new SqlParameter("@cat", cat));
                var reader = command.ExecuteReader();

                while(reader.Read()) //Lies die nächste Zeile der Treffermenge
                {
                    res= (int)reader[0];
                }
            }
            return res;
        }
        public List<KeyValuePair<string,int>> GetNumberOfItemsForCats(){
            
            List<KeyValuePair<string,int>> res = new();
            using(var connection = dbProviderFactory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open(); //erst jetzt wird physikalisch eine Netzwerkverbindung zur Datenbank aufgebaut

                DbCommand command = dbProviderFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "SELECT CATEGORY AS cat, COUNT(ITEM) AS quantity FROM STORE GROUP BY CATEGORY";
                var reader = command.ExecuteReader();

                while(reader.Read()) //Lies die nächste Zeile der Treffermenge
                {
                    res.Add(new KeyValuePair<string, int>((string)reader["cat"],(int)reader["quantity"]));
                }
            }
            return res;
        }
        public void DeleteItem(string category, string item){
             using(var connection = dbProviderFactory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open(); //erst jetzt wird physikalisch eine Netzwerkverbindung zur Datenbank aufgebaut

                DbCommand command = dbProviderFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM STORE WHERE CATEGORY = @cat AND ITEM = @item";
                command.Parameters.Add(new SqlParameter("@cat",category));
                command.Parameters.Add(new SqlParameter("@item",item.ToString()));
                var reader = command.ExecuteNonQuery();

            }
        }
        public void DeleteCat(string category){
            using(var connection = dbProviderFactory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open(); //erst jetzt wird physikalisch eine Netzwerkverbindung zur Datenbank aufgebaut

                DbCommand command = dbProviderFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM STORE WHERE CATEGORY = @cat";
                command.Parameters.Add(new SqlParameter("@cat",category));
                var reader = command.ExecuteNonQuery();

            }
        }
    }
}