using System;

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

            var commandString = "SELECT * FROM Movies.Movie";
        }
    }
}
