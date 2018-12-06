using EFDBFirstDemo.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace EFDBFirstDemo.Testing.DataAccess
{
    public class MovieRepositoryTests
    {
        [Fact]
        public void SaveChangesWithNoChangesDoesntThrowException()
        {
            var options = new DbContextOptionsBuilder<adventureworksContext>()
                .UseInMemoryDatabase("no_changes_test").Options;
            using (var db = new adventureworksContext(options))
            {
                var repo = new MovieRepository(db);
                repo.SaveChanges();
            }
        }

        [Fact]
        public void CreateMovieWorks()
        {
            var options = new DbContextOptionsBuilder<adventureworksContext>()
                .UseInMemoryDatabase("create_movie_test").Options;

            using (var db = new adventureworksContext(options))
            {
                db.Genre.Add(new Genre {Name = "a" });
                db.SaveChanges();
            }

            using (var db = new adventureworksContext(options))
            {
                var repo = new MovieRepository(db);
                Movie movie = new Movie { Name = "b" };
                repo.CreateMovie(movie, "a");
                repo.SaveChanges();
            }

            using (var db = new adventureworksContext(options))
            {
                Movie movie = db.Movie.Include(m => m.Genre).First(m => m.Name == "b");
                Assert.Equal("b", movie.Name);
                Assert.NotNull(movie.Genre);
                Assert.Equal("a", movie.Genre.Name);
                Assert.NotEqual(0, movie.Id);
            }
        }
        [Fact]
        public void CreateMovieWithoutSaveChangesDoesntWork()
        {
            var options = new DbContextOptionsBuilder<adventureworksContext>()
                .UseInMemoryDatabase("create_movie_test").Options;

            using (var db = new adventureworksContext(options))
            {
                db.Genre.Add(new Genre { Name = "a" });
                db.SaveChanges();
            }

            using (var db = new adventureworksContext(options))
            {
                var repo = new MovieRepository(db);
                Movie movie = new Movie { Name = "b" };
                repo.CreateMovie(movie, "a");
                //repo.SaveChanges();
            }

            using (var db = new adventureworksContext(options))
            {
                Movie movie = db.Movie.Include(m => m.Genre).FirstOrDefault(m => m.Name == "b");
                Assert.Null(movie);
            }
        }

        [Fact]
        public void GetMovieByIdReturnsCorrectMovie()
        {
            var options = new DbContextOptionsBuilder<adventureworksContext>()
                .UseInMemoryDatabase("get_movie_by_id_test").Options;
            using (var db = new adventureworksContext(options))
            {
                var repo = new MovieRepository(db);
                Movie movie = repo.GetMovieById(1);

                Assert.Equal(db.Movie.Find(1), movie);
            }
        }

        [Fact]
        public void GetMovieByNameReturnsCorrectMovie()
        {
            var options = new DbContextOptionsBuilder<adventureworksContext>()
                .UseInMemoryDatabase("get_movie_by_name_test").Options;
            using (var db = new adventureworksContext(options))
            {
                db.Genre.Add(new Genre { Name = "a" });
                db.SaveChanges();
            }
            using (var db = new adventureworksContext(options))
            {
                var repo = new MovieRepository(db);
                Movie movie = new Movie { Name = "b" };
                repo.CreateMovie(movie, "a");
                repo.SaveChanges();
            }
            using (var db = new adventureworksContext(options))
            {
                var repo = new MovieRepository(db);
                Movie movie = repo.GetMovieByName("b");

                Assert.Equal(db.Movie.First(m => m.Name == "b"), movie);
            }
        }
    }
}
