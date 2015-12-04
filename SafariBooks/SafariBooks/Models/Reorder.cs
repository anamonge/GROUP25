using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace SafariBooks.Models
{
    public class Reorders
    {

        public int ReordersID { get; set; }

        //[ForeignKey("EmployeeID")]
        public int EmployeeID { get; set; }

        public virtual List<Employee> Employee { get; set; }
        public virtual List<ReorderDetails> ReorderDetails { get; set; }

    }

}