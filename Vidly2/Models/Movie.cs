using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter movie name")]
        [StringLength(250)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Please enter a genre")]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required(ErrorMessage = "Please enter a date in the format 01 Jan 2000")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Range(0,20)]
        [Display (Name ="Number In Stock")]
        public int NumberInStock { get; set; }
    }
}