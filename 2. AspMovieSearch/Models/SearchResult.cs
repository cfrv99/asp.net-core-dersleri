using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMovieSearch.Models
{
    class SearchResult
    {
        public List<Movie> Search { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }
}
