using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SafariBooks.Models
{
    public class Review
    {

        public string ReviewID { get; set; }
        public string EmployeeID { get; set; }
        public string CustomerID { get; set; }
        public string Rating { get; set; }

        [Display(Name = "Book Review")]
        [StringLength(100)]
        public string BookReview { get; set; }

        public string BookID { get; set; }

        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }


    }
}