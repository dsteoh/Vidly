using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        //Example of a pure View Model
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter movie name")]
        [StringLength(250)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a genre")]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required(ErrorMessage = "Please enter a date in the format 01 Jan 2000")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Range(0, 20)]
        [Display(Name = "Number In Stock")]
        [Required]
        public int? NumberInStock { get; set; }

        public DateTime DateAdded { get; set; }

        public string Title
        {
            get { return Id != 0 ? "Edit Movie" : "New Movie"; }
        }

        public MovieFormViewModel()
        {
            Id = 0;
            DateAdded = DateTime.Now;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}