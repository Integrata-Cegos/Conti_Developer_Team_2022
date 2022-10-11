using Javacream.Store.API;
using System.Data.Common;
using System.Data.SqlClient;
namespace Javacream.Store.Impl
{
    public class DatabaseStoreService : IStoreService
    {
        private readonly string connectionString = "data source=qrbg.conti.de; initial catalog=training;persist security info=True; Integrated Security=SSPI; Database=c1tt";
        private DbProviderFactory sqlFactory = System.Data.SqlClient.SqlClientFactory.Instance;

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

        public void DeleteItemFromStore(string category, object item)
        {
            if (item == null)
            {
                throw new ArgumentException("null item");
            }
            using (var connection = sqlFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = sqlFactory.CreateCommand();
                try
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM store WHERE CATEGORY = @category AND ITEM =  @item;";
                    command.Parameters.Add(new SqlParameter("@item", item));
                    command.Parameters.Add(new SqlParameter("@category", category));
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    //Console.WriteLine(e.Message);
                    //command.CommandText = "update store set stock = @stock where category = @category and item= @item";
                    //command.ExecuteNonQuery();
                }
            }

        }

        public Dictionary<string, int> GetNumberOfItemsForCategories()
        {
            Dictionary<string, int> result = new();
            using (var connection = sqlFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = sqlFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select category, count(category)  from store group by category;";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        result.Add(reader.GetString(0),reader.GetInt32(1));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return null;
                    }
                }
                return result;
            }
        }

        public List<string> GetCategories()
        {
            List<string> categories = new List<string>();
            using (var connection = sqlFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = sqlFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select distinct category from store;";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        categories.Add(reader.GetString(0));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return null;
                    }
                }
                return categories;
            }
        }

        public int GetNumberOfItemsFor(string category)
        {
            if (category == null)
            {
                throw new ArgumentException("null category");
            }
            using (var connection = sqlFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = sqlFactory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select count(category) from store where category = @category";
                command.Parameters.Add(new SqlParameter("@category", category));
                var reader = command.ExecuteReader();
                try
                {
                    reader.Read();
                    int count = reader.GetInt32(0);
                    return count;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 0;
                }
            }

        }

        public int GetStock(string category, Object item)
        {
            if (category == null)
            {
                throw new ArgumentException("null category");
            }
            if (item == null)
            {
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
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return 0;
                }
            }
        }
        public void SetStock(string category, Object item, int stock)
        {
            if (category == null)
            {
                throw new ArgumentException("null category");
            }
            if (item == null)
            {
                throw new ArgumentException("null item");
            }
            if (stock < 0)
            {
                throw new ArgumentException("negative stock");
            }

            using (var connection = sqlFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = sqlFactory.CreateCommand();
                    var transaction = connection.BeginTransaction();
                    command.Connection = connection;
                    command.Transaction = transaction;
                    command.CommandText = "insert into store (category,item, stock) Values (@category, @item, @stock)";
                    command.Parameters.Add(new SqlParameter("@category", category));
                    command.Parameters.Add(new SqlParameter("@item", item));
                    command.Parameters.Add(new SqlParameter("@stock", stock));
                    command.ExecuteNonQuery();
                try
                {
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    //Console.WriteLine(e.Message);
                }
            }
        }
    }

}