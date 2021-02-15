using JCV.Exercises.MovieAPI.Core.Services;
using JCV.Exercises.MovieAPI.Core.Repositories;
using JCV.Exercises.MovieAPI.Core.Models;
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
    public class MetadataController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MetadataController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieInfo movie)
        {
            await _movieRepository.Create(movie);

            return CreatedAtAction("GetMovie", movie.MovieId);
        } 

        [HttpGet("{movieId}")]
        public async Task<ActionResult<List<MovieInfo>>> GetMovie(int movieId) {
            var movieInfo = await _movieRepository.Get(movieId);

            if (movieInfo is null || movieInfo.Count == 0)
            {
                return NotFound();
            }

            return movieInfo;
        }
    }
}
