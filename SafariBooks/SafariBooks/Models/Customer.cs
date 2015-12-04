using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SafariBooks.Models
{
    public class Customer
    {

        [Required]
        public string CustomerID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [StringLength(1)]
        [Display(Name = "Middle Initial")]
        public string MInitial { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [PhoneAttribute]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid phone number.")]
        public int Phone { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string Address { get; set; }


        [Required]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip")]
        public int ZipCode { get; set; }




        [CreditCard]
        [Display(Name = "Credit Card #1")]
        public string Card1 { get; set; }


        public enum Cards { Visa, Mastercard, AmericanExpress, Discover }
        [Display(Name = "Type of Card")]
        public Cards Card { get; set; }




        [CreditCard]
        [Display(Name = "Credit Card #2")]
        public string Card2 { get; set; }

        [Display(Name = "Type of Card")]
        public Cards Cards2 { get; set; }



        [CreditCard]
        [Display(Name = "Credit Card #3")]
        public string Card3 { get; set; }

        [Display(Name = "Type of Card")]
        public Cards Cards3 { get; set; }



        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        public virtual List<Order> Order { get; set; }

        public virtual List<Review> Review { get; set; }

    }
}