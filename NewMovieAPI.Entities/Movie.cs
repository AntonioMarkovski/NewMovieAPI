using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewMovieAPI.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
