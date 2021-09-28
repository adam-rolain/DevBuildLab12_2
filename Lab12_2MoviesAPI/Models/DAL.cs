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
    }
}
