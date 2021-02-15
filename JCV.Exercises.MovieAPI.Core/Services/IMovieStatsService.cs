using JCV.Exercises.MovieAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JCV.Exercises.MovieAPI.Core.Services
{
    public interface IMovieStatsService
    {
        Task<List<MovieStats>> GetAll();
    }
}
