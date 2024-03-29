using Javacream.Store.API;
using System.Data.Common;
using System.Data.SqlClient;
namespace Javacream.Store.Impl{
    public class DatabaseStoreService : IStoreService
    {
        private readonly string connectionString = "Data Source=h2908727.stratoserver.net;Initial Catalog=publishing;User ID=teilnehmer;Password=teilnehmer123!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private DbProviderFactory sqlFactory = System.Data.SqlClient.SqlClientFactory.Instance;

        public int GetStock(string category, Object item)
        {
            if (category == null){
                throw new ArgumentException("null category");
            }
            if (item == null){
                throw new ArgumentException("null item");
            }
            using (var connection = sqlFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = sqlFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select stock from store where category = @category and item = @item";
                command.Parameters.Add(new SqlParameter("@category", category));
                command.Parameters.Add(new SqlParameter("@item", item));
                var reader = command.ExecuteReader();
                try
                {
                    reader.Read();
                    int stock = (int)reader["stock"];
                    return stock;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 0;
                }
            }
        }
        public void SetStock(string category, Object item, int stock){
            if (category == null){
                throw new ArgumentException("null category");
            }
            if (item == null){
                throw new ArgumentException("null item");
            }
            if (stock < 0){
                throw new ArgumentException("negative stock");
            }

            using (var connection = sqlFactory.CreateConnection())
             {

                connection.ConnectionString = connectionString;
                connection.Open();
                var transaction = connection.BeginTransaction();
                DbCommand command = sqlFactory.CreateCommand();
                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandText = "delete from store where category=@category and item= @item";
                command.Parameters.Add(new SqlParameter("@category", category));
                command.Parameters.Add(new SqlParameter("@item", item));
                command.ExecuteNonQuery();
                command.CommandText = "insert into store (category,item, stock) Values (@category, @item, @stock)";
                command.Parameters.Add(new SqlParameter("@stock", stock));
                command.ExecuteNonQuery();
                command.CommandText = "insert into MESSAGES  Values (@message)";
                command.Parameters.Add(new SqlParameter("@message", "updated stock"));
                command.ExecuteNonQuery();

                try
                {
                    transaction.Commit();
                }
                catch(Exception e)
                {
                    Console.WriteLine("UNABLE TO COMMIT!");
                }
            }
          }
     
         public int GetNumberOfItemsFor(string category)
         {
            using (var connection = sqlFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = sqlFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select count(*) as count from store where category=@category";
                command.Parameters.Add(new SqlParameter("@category", category));
                var reader = command.ExecuteReader();
                reader.Read();
                return (int)reader["count"];
            }

         }

        public List<string> GetNumberOfItemsForCategories(){
           using (var connection = sqlFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = sqlFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select count(*) as count, category from store group by category ";
                var reader = command.ExecuteReader();
                List<string> numbersForCategory = new List<string>();
                while(reader.Read()){
                    numbersForCategory.Add((string)reader["category"] + ":" + reader["count"].ToString());
                }
                return numbersForCategory;
            }
 
        }

         public List<String> GetCategories()
        {
            using (var connection = sqlFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = sqlFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select distinct category from store";
                var reader = command.ExecuteReader();
                List<string> categories = new List<string>();
                while(reader.Read()){
                    categories.Add((string)reader["category"]);
                }
                    return categories;
            }
        }
       public void DeleteItem(string category, Object item)
       {
            using (var connection = sqlFactory.CreateConnection())
             {

                connection.ConnectionString = connectionString;
                connection.Open();
                var transaction = connection.BeginTransaction();
                DbCommand command = sqlFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "delete from store where category = @category and item=@item";
                command.Parameters.Add(new SqlParameter("@category", category));
                command.Parameters.Add(new SqlParameter("@item", item));
                command.ExecuteNonQuery();
                //TODO: Fehlerbehandlung bei nicht-erfolgreichem commit
                transaction.Commit();
          }

       }
        public void DeleteCategory(string category)
        {
            using (var connection = sqlFactory.CreateConnection())
             {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = sqlFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "delete from store where category = @category";
                command.Parameters.Add(new SqlParameter("@category", category));
                command.ExecuteNonQuery();
          }

        }

    }

}