using System;
using System.Data;
using System.Data.SqlClient;

namespace ADO.NETDisconnected
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = SecretConfiguration.connectionString;

            Console.WriteLine("Enter Name of Movie:");
            var input = Console.ReadLine();
            var commandString = $"SELECT * FROM Movies.Movie WHERE Name = '{input}'";

            //Disconnected architecture: wait to get the whole result, load it into data set, close connection

            var dataSet = new DataSet();

            using (var connection = new SqlConnection(connectionString))
            {
                //step 1: open connection
                connection.Open();
                // step 2: execute query
                using (var command = new SqlCommand(commandString, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataSet);
                }
                // step 3: close connection    
                connection.Close();
                //step 4: process results
                var firstTable = dataSet.Tables[0];
                foreach(DataRow row in firstTable.Rows)
                {
                    object id = row["ID"];
                    object name = row["Name"];
                    Console.WriteLine($"ID: {id}, Name: {name}");
                }
            }
        }
    }
}
