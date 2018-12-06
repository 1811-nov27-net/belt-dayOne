using EFDBFirstDemo.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFDBFirstDemo.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = SecretConfiguration.connectionString;

            var optionsBuilder = new DbContextOptionsBuilder<adventureworksContext>();
            optionsBuilder.UseSqlServer(connectionString);
            var options = optionsBuilder.Options;

            var movies = new List<Movie>();
            using (var db = new adventureworksContext(options))
            {
                movies = db.Movie.ToList();
            }

            foreach (var item in movies)
            {
                Console.WriteLine($"movie ID {item.Id}, name {item.Name}");
            }
        }
    }
}
