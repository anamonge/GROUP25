using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafariBooks.Models
{
    public class Promotion
    {

        public int PromotionID { get; set; }

        public decimal Value { get; set; }

        public int CustomerID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual List<Order> Order { get; set; }

    }
}