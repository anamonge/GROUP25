using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafariBooks.Models
{
    public class Order
    {

        public int OrderID { get; set; }

        [Required]
        //[ForeignKey("CustomerID")]
        public int CustomerID { get; set; }


        //[ForeignKey("PromotionID")]
        public int PromotionID { get; set; }

        public virtual List<Customer> Customer { get; set; }
        public virtual List<OrderDetail> OrderDetail { get; set; }
        public virtual List<Promotion> Promotion { get; set; }

    }
}