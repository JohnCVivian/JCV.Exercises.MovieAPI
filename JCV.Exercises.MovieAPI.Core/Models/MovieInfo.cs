using System;
using System.Collections.Generic;
using System.Text;

namespace JCV.Exercises.MovieAPI.Core.Models
{
    public class MovieInfo
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public TimeSpan Duration { get; set; }

        public string ReleaseYear { get; set; }

    }
}
