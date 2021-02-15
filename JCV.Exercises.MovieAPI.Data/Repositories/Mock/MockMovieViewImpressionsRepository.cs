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
    public class MockMovieViewImpressionsRepository : IMovieViewImpressionsRepository
    {
        List<MovieViewImpression> Impressions { get; set; }
        public MockMovieViewImpressionsRepository()
        {
            // File name should come for IConfiguration in the Appsettings.json 
            string filename = "Samples\\stats.csv";
            Impressions = new List<MovieViewImpression>();

            LoadMoviesFromCSV(filename);
        }
        public Task<List<MovieViewImpression>> Get()
        {
            return Task.FromResult(Impressions);
        }

        private void LoadMoviesFromCSV(string fileName)
        {
            Impressions = File.ReadAllLines(fileName)
                .Skip(1)
                .Select(line => GetMovieViewImpressionFromCSVLine(line))
                .ToList();
        }

        private static MovieViewImpression GetMovieViewImpressionFromCSVLine(string line)
        {
            // Should use morte robust Type Conversions / error checking
            string[] fields = line.Split(',');

            return new MovieViewImpression
            {
                MovieId = int.Parse(fields[0]),
                watchDurationMs = int.Parse(fields[1])
            };
        }
    }
}
