using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMovieSearch.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
