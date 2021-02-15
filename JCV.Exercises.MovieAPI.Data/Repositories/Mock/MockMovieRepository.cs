using JCV.Exercises.MovieAPI.Core.Models;
using JCV.Exercises.MovieAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCV.Exercises.MovieAPI.Data.Repositories.Mock
{
    public class MockMovieRepository : IMovieRepository
    {
        List<MovieInfo> Movies { get; set; }
        public MockMovieRepository (string fileName)
        {
            Movies = new List<MovieInfo>();

            LoadMoviesFromCSV(fileName);
        }

        public Task Create(MovieInfo movie)
        {
            Movies.Add(movie);
            return Task.FromResult(0);
        }

        public Task<List<MovieInfo>> Get(int movieId)
        {
            var movieInfo = Movies.FindAll(movie => movie.MovieId == movieId);
            return Task.FromResult(movieInfo);
        }

        private void LoadMoviesFromCSV(string fileName)
        {
            Movies = File.ReadAllLines(fileName)
                .Skip(1)
                .Select(line => GetMovieFromCSVLine(line))
                .ToList();
        }

        private static MovieInfo GetMovieFromCSVLine(string line)
        {
            // Should use morte robust Type Conversions / error checking
            string[] fields = line.Split(',');

            return new MovieInfo
            {
                Id = int.Parse(fields[0]),
                MovieId = int.Parse(fields[1]),
                Title = fields[2],
                Language = fields[3],
                Duration = TimeSpan.Parse(fields[4]),
                ReleaseYear = fields[5]
            };
        }
    }
}
