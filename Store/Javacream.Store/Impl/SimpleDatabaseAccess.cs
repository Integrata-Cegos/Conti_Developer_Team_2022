using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;

namespace Javacream.Store.Impl;

public class DataBaseDemo
{
    public void DoDemo()
    {

    string connectionString = "data source=qrbg.conti.de; initial catalog=training;persist security info=True; Integrated Security=SSPI; Database=c1tt";
    //string connectionString = "Data Source=h2908727.stratoserver.net;Initial Catalog=publishing;User ID=teilnehmer;Password=teilnehmer123!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    DbProviderFactory dbProviderFactory = SqlClientFactory.Instance;
        using (var connection = dbProviderFactory.CreateConnection())
        {
            connection.ConnectionString = connectionString;
            connection.Open(); //erst jetzt wird physikalisch eine Netzwerkverbindung zur Datenbank aufgebaut

            DbCommand command = dbProviderFactory.CreateCommand();
            command.Connection = connection;
            command.CommandText = "select * from STORE";

            var reader = command.ExecuteReader();

            while (reader.Read()) //Lies die nächste Zeile der Treffermenge
            {
                Console.WriteLine(reader["category"]);
            }
        }
    }

}