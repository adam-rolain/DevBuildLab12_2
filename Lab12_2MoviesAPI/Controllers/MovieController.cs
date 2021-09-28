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
        // https://localhost:44359/api/Movie
        [HttpGet]
        public List<Movie> GetAll()
        {
            return DAL.GetAllMovies();
        }

        // https://localhost:44359/api/Movie/Category?catId=SCIFI
        [HttpGet("Category")]
        public List<Movie> GetMoviesByCategory(string catId)
        {
            return DAL.GetMoviesByCategory(catId);
        }
    }
}
