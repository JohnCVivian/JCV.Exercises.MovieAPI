using JCV.Exercises.MovieAPI.Core.Models;
using JCV.Exercises.MovieAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JCV.Exercises.MovieAPI.Data.Repositories.Mock
{
    public class MockMovieRepository : IMovieRepository
    {
        List<MovieInfo> Movies { get; set; }
        public MockMovieRepository ()
        {
            // File name should come for IConfiguration in the Appsettings.json 
            string filename = "Samples\\metadata.csv";

            Movies = new List<MovieInfo>();

            LoadMoviesFromCSV(filename);
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

            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            string[] fields = CSVParser.Split(line);

            return new MovieInfo
            {
                Id = int.Parse(fields[0]),
                MovieId = int.Parse(fields[1]),
                Title = fields[2],
                Language = fields[3],
                Duration = fields[4],
                ReleaseYear = fields[5]
            };
        }
    }
}
