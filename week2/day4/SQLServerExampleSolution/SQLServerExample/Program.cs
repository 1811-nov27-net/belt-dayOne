using System;
using System.Data.SqlClient;

namespace SQLServerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // ADO.NET == Umbrella Name for data-related libraries
            // Ususally refers to older way: DataReader, DataAdapter objects.

            //In code, use "connection string" to contain Server URL, Login, password
            var connectionString = SecretConfiguration.connectionString;

            //var commandString = "SELECT * FROM Movies.Movie";

            Console.WriteLine("Enter Name of Movie:");
            var input = Console.ReadLine();
            var commandString = $"SELECT * FROM Movies.Movie WHERE Name = '{input}'";
            //allows SQL injection
            //unchecked user input should not be used to construct SQL queries, security risk

            using (var connection = new SqlConnection(connectionString))
            {
                //step 1: open connection
                connection.Open();
                //step 2: Execute query
                using (var command = new SqlCommand(commandString, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //command.ExecuteReader() returns data
                    //command.ExecuteNonQuery() returns int for number of rows returned
                    //step 3: Process data
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var id = reader["ID"];
                            var name = reader["Name"];
                            Console.WriteLine($"ID: {id}, Name: {name}");
                        }
                    }
                }
                //step 4: close connection
                connection.Close();
            }
        }
    }
}
