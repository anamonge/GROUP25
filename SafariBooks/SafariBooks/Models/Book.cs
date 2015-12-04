using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SafariBooks.Models
{
    public class Book
    {

        [Required]
        [Display(Name = "Unique Number")]
        public int BookID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Author First Name")]
        public string AuthorFirst { get; set; }

        [Required]
        [Display(Name = "Author Last Name")]
        public string AuthorLast { get; set; }

        [Required]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Publication Date")]
        public DateTime PublicationDate { get; set; }

        [Required]
        [Display(Name = "Price Last Paid")]
        [DataType(DataType.Currency)]
        public int PriceLastPaid { get; set; }

        [Required]
        [Display(Name = "Inventory")]
        public int Inventory { get; set; }

        [Required]
        [Display(Name = "Reorder Point")]
        public int ReorderPoint { get; set; }


        public virtual List<Genre> Genre { get; set; }

        public virtual List<Review> Review { get; set; }


    }
}