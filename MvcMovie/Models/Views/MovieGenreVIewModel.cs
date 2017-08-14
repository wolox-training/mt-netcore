using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using MvcMovie.Models.Database;

namespace MvcMovie.Models.Views
{
    public class MovieGenreViewModel
    {
        public PaginatedList<Movie> movies;
        public SelectList genres;
        public string movieGenre { get; set; }
    }
}
