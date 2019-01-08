using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NermeenVidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberInStock { get; set; }

        public DateTime DateAdded { get; set; }


        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        public Genre Genre { get; set; }
        public int GenreId { get; set; }


        public DateTime testDate { get; set; }


    }
}