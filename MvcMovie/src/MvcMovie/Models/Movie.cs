using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MvcMovie.CustomAttributes;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        [ClassicMovie(1960)]
        public DateTime ReleaseDate { get; set; }

        
        public string Genre { get; set; }

        [Range(0, 999.99)]
        public decimal Price { get; set; }

        [Range(0,100)]
        public int Rating { get; set; }


        /*

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Genre == Genre.Classic && ReleaseDate.Year > _classicYear)
            {
                yield return new ValidationResult(
                    "Classic movies must have a release year earlier than " + _classicYear,
                    new[] { "ReleaseDate" });
            }
        }
        */
    }


}
