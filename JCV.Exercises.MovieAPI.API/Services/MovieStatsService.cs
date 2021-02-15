using JCV.Exercises.MovieAPI.Core.Models;
using JCV.Exercises.MovieAPI.Core.Services;
using JCV.Exercises.MovieAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JCV.Exercises.MovieAPI.API.Services
{
    public class MovieStatsService : IMovieStatsService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieViewImpressionsRepository _movieViewImpressionsRepository;

        public MovieStatsService(IMovieRepository movieRepository, IMovieViewImpressionsRepository movieViewImpressionsRepository)
        {
            _movieRepository = movieRepository;
            _movieViewImpressionsRepository = movieViewImpressionsRepository;
        }

        public async Task<List<MovieStats>> GetAll()
        {
            List<MovieStats> movieStats = new List<MovieStats>();

            Dictionary<int, List<MovieViewImpression>> collectedImpressions = new Dictionary<int, List<MovieViewImpression>>();
            List<MovieViewImpression> movieImpressions = await _movieViewImpressionsRepository.Get();

            foreach (var movieImpression in movieImpressions)
            {
                if (collectedImpressions.ContainsKey(movieImpression.MovieId)) {
                    collectedImpressions[movieImpression.MovieId].Add(movieImpression);
                } else
                {
                    collectedImpressions.Add(movieImpression.MovieId, new List<MovieViewImpression> { movieImpression });
                }
            }

            foreach (int movieId in collectedImpressions.Keys)
            {
                List<MovieInfo> movieInfo = await _movieRepository.Get(movieId);
                MovieInfo movie = movieInfo.FirstOrDefault(movie => movie.Language == "EN");

                // Fallback if no EN
                if (movie is null)
                {
                    movie = movieInfo.FirstOrDefault();
                }

                var averageWatchDurationMS = collectedImpressions[movieId].Average(movieImpressions => movieImpressions.watchDurationMs);
                var averageWatchDurationS = (int)Math.Round(averageWatchDurationMS * 1000);

                movieStats.Add(new MovieStats
                {
                    MovieId = movieId,
                    Title = movie.Title,
                    ReleaseYear = movie.ReleaseYear,
                    AverageWatchDurationS = averageWatchDurationS,
                    Watches = collectedImpressions[movieId].Count
                });
            }

            return movieStats;
        }
    }
}
