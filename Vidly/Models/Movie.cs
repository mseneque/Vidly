using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Movie Title")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }

        public MovieGenre MovieGenre { get; set; }

        [Display(Name = "Genre")]
        public byte? MovieGenreId { get; set; }

    }

}