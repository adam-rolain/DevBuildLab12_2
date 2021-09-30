using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;

namespace Lab12_2MoviesAPI.Models
{
    public class DAL
    {
        public static MySqlConnection DB;

        public static List<Movie> GetAllMovies()
        {
            return DB.GetAll<Movie>().ToList();
        }

        public static List<Movie> GetMoviesByCategory(string categoryId)
        {
            return DB.Query<Movie>("SELECT * FROM movie WHERE category = @categoryId", new { categoryId = categoryId }).ToList();
        }

        public static Movie GetMovieById(int id)
        {
            return DB.Get<Movie>(id);
        }

        public static Movie GetRandomMovie()
        {
            Random random = new Random();
            var maxValue = DB.Query<int>("SELECT COUNT(id) FROM movie");
            int randomId = random.Next(1, maxValue.First() + 1);

            return GetMovieById(randomId);
        }

        public static Movie GetRandomMovieinCategory(string catId)
        {
            List<Movie> moviesInCategory = GetMoviesByCategory(catId);
            Random random = new Random();
            int randomIdInList = random.Next(moviesInCategory.Count);
            int id = moviesInCategory[randomIdInList].Id;

            return GetMovieById(id);
        }

        public static List<Movie> GetRandomMovieList(int numberOfMovies)
        {
            List<Movie> randomMovies = new List<Movie>();

            while (numberOfMovies > 0)
            {
                bool movieOnList = false;
                Movie currentMovie = DAL.GetRandomMovie();

                foreach (Movie movie in randomMovies)
                {
                    if (movie.Id == currentMovie.Id)
                    {
                        movieOnList = true;
                        break;
                    }
                }
                
                if (!movieOnList)
                {
                    randomMovies.Add(currentMovie);
                    numberOfMovies--;
                }
            }

            return randomMovies;
        }

        public static List<string> GetAllCategories()
        {
            return DB.Query<string>("SELECT DISTINCT category FROM movie").ToList();
        }

        public static Movie GetMovieByTitle(string movieTitle)
        {
            List<Movie> queryResult = DB.Query<Movie>("SELECT * FROM movie WHERE name = @movieTitle", new { movieTitle = movieTitle}).ToList();
            if (queryResult.Count > 0)
            {
                return queryResult[0];
            }
            else
            {
                return null;
            }
        }

        public static List<Movie> GetMovieByTitleSearch(string searchString)
        {
            return DB.Query<Movie>("SELECT * FROM movie WHERE name LIKE @searchString", new { searchString = $"%{searchString}%" }).ToList();
        }

        public static long InsertMovie(Movie movie)
        {
            return DB.Insert<Movie>(movie);
        }

        public static bool DeleteMovie(int movieId)
        {
            return DB.Delete<Movie>(new Movie() { Id = movieId });
        }

        public static bool UpdateMovie(Movie movie)
        {
            return DB.Update<Movie>(movie);
        }
    }
}
