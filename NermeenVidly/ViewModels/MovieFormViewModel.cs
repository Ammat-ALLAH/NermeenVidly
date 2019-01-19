using NermeenVidly.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NermeenVidly.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            Id = 0;
        }
        public int? Id { get; set; }

        [Required]
       // [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(1,20 , ErrorMessage = "Number Of stock  should be in range of 1 and 20")]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Date Added")]

        public DateTime? DateAdded { get; set; }


        [Required]
        [Display(Name = "Release Added")]

        public DateTime? ReleaseDate { get; set; }

        [Required]
        public int GenreId { get; set; }


        public List<Genre> Genres { get; set; }

        public string Title {
            get { return (Id == null || Id == 0) ? "New Movie" : "Edit Movie"; }

           
        }
    }
}