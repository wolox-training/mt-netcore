using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Comment
    {
        public int ID { get; set; }

        [StringLength(140, MinimumLength = 3)]
        public string Text { get; set; }
        
        public int MovieID { get; set; }
        public Movie Movie { get; set; }

    }
}