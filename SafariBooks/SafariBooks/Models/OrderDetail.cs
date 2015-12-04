using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafariBooks.Models
{
    public class OrderDetail
    {

        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        public int Quantity { get; set; }

        public int BookID { get; set; }

        public virtual Book Book { get; set; }

        public virtual Order Order { get; set; }

    }
}