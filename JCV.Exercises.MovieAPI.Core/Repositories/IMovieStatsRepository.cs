using JCV.Exercises.MovieAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JCV.Exercises.MovieAPI.Core.Repositories
{
    public interface IMovieStatsRepository
    {
        Task<List<MovieStats>> Get();
    }
}
