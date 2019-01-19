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
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Range(1, 20, ErrorMessage = "Number Of stock  should be in range of 1 and 20")]
        public int NumberInStock { get; set; }
        [Required]

        public DateTime DateAdded { get; set; }

        [Required]

        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        public Genre Genre { get; set; }
        public int GenreId { get; set; }



    }
}