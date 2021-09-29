using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab12_2MoviesAPI.Models;

namespace Lab12_2MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // GET https://localhost:44359/api/Movie
        [HttpGet]
        public List<Movie> GetAll()
        {
            return DAL.GetAllMovies();
        }

        // GET https://localhost:44359/api/Movie/Category?catId=SCIFI
        [HttpGet("Category")]
        public List<Movie> GetMoviesByCategory(string catId)
        {
            return DAL.GetMoviesByCategory(catId);
        }

        // GET https://localhost:44359/api/Movie/Random
        [HttpGet("Random")]
        public Movie GetRandomMovie()
        {
            return DAL.GetRandomMovie();
        }

        // GET https://localhost:44359/api/Movie/Random/HIST
        [HttpGet("Random/Category/{catId}")]
        public Movie GetRandomMovieInCategory(string catId)
        {
            return DAL.GetRandomMovieinCategory(catId);
        }

        // GET https://localhost:44359/api/Movie/Random/8
        [HttpGet("Random/List{numberOfMovies}")]
        public List<Movie> GetRandomMovieList(int numberOfMovies)
        {
            return DAL.GetRandomMovieList(numberOfMovies);
        }

        // GET https://localhost:44359/api/Movie/Categories
        [HttpGet("Categories")]
        public List<string> GetAllCategories()
        {
            return DAL.GetAllCategories();
        }

        // GET https://localhost:44359/api/Movie/Title?movieTitle=inception
        [HttpGet("Title")]
        public Movie GetMovieDetails(string movieTitle)
        {
            return DAL.GetMovieByTitle(movieTitle);
        }

        // GET https://localhost:44359/api/Movie/Search?searchString=king
        [HttpGet("Search")]
        public List<Movie> GetMovieListBySearch(string searchString)
        {
            return DAL.GetMovieByTitleSearch(searchString);
        }
    }
}
