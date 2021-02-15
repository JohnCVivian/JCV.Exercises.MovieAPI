using System;
using System.Collections.Generic;
using System.Text;

namespace JCV.Exercises.MovieAPI.Core.Models
{
    public class MovieStats
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int AverageWatchDurationS { get; set; }
        public int Watches { get; set; }
        public string ReleaseYear { get; set; }
    }
}
