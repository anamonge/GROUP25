using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SafariBooks.Models
{
    public class Discounts
    {
        [Key]
        [Required(ErrorMessage = "Enter Discount Code")]
        [Display(Name = "Discount Code")]
        [StringLength(20, MinimumLength = 1,
   ErrorMessage = "Code Should be 20 Characters long")]
        public string DiscountsID { get; set; }


        [Required(ErrorMessage = "Enter Discount Name")]
        [Display(Name = "Discount Name")]
        public string discountname { get; set; }



        [Required(ErrorMessage = "Enter value")]
        [Display(Name = "Enter Value of discount")]

        public decimal value { get; set; }


        public virtual Book Books { get; set; }
       
    }
}