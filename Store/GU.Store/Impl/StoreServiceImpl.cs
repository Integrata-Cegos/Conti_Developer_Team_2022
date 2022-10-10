using GU.Store.API;
using System.Data.Common;
using System.Data.SqlClient;
namespace GU.Store.Impl{
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
                DbCommand command = sqlFactory.CreateCommand();
                try{
                    command.Connection = connection;
                    command.CommandText = "insert into store (category,item, stock) Values (@category, @item, @stock)";
                    command.Parameters.Add(new SqlParameter("@category", category));
                    command.Parameters.Add(new SqlParameter("@item", item));
                    command.Parameters.Add(new SqlParameter("@stock", stock));
                    command.ExecuteNonQuery();
                }
                catch(SqlException e)
                {
                    //Console.WriteLine(e.Message);
                    command.CommandText = "update store set stock = @stock where category = @category and item= @item";
                    command.ExecuteNonQuery();
                }
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
                    categories.Add(reader['category']);
                }
                    return categories;
            }
        }

    }

}