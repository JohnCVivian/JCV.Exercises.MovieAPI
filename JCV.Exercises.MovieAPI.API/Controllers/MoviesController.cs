using JCV.Exercises.MovieAPI.Core.Models;
using JCV.Exercises.MovieAPI.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JCV.Exercises.MovieAPI.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieStatsService _movieStatsService;

        public MoviesController(IMovieStatsService movieStatsService)
        {
            _movieStatsService = movieStatsService;
        }

        [HttpGet("/stats")]
        public async Task<ActionResult<List<MovieStats>>> GetMovieStats(int movieId)
        {
            var movieStats = await _movieStatsService.GetAll();

            if (movieStats is null || movieStats.Count == 0)
            {
                return NotFound();
            }

            return movieStats;
        }

    }
}
