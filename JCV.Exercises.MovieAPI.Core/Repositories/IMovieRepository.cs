using JCV.Exercises.MovieAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JCV.Exercises.MovieAPI.Core.Repositories
{
    public interface IMovieRepository
    {
        Task Create(MovieInfo movie);

        Task<MovieInfo> Get(int id);
    }
}
