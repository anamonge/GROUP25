using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SafariBooks.Models
{
    public class Genre
    {
        [Required]
        public int GenreID { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public string GenreName { get; set; }


        public int BookID { get; set; }
        public virtual Book Book { get; set; }


    }
}