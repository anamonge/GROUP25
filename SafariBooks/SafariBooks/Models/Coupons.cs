using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SafariBooks.Models
{
    public class Coupons
    {
    [Key]
        [Required(ErrorMessage = "Enter Promotion Code")]
        [Display(Name = "Promotion Code")]
        [StringLength(20, MinimumLength = 1,
   ErrorMessage = "Code Should be 20 Characters long")]
        public string CouponsID { get; set; }


        public enum CouponType { [Display(Name = "On Shipping")] Shipping, [Display(Name = "On Order")] Order };

        [Required(ErrorMessage = "Coupon Type")]
        [Display(Name = "CouponType")]
        public CouponType? CouponTypes { get; set; }

        [Required(ErrorMessage = "Enter Promotion Details")]
        [Display(Name = "Promotion Details")]
        public string PromotionDetails { get; set; }

        [Required(ErrorMessage = "Enter Value of the Coupon")]
        [Display(Name = "Coupon Value")]
        public decimal Couponvalue { get; set; }

        public virtual List<Order>order { get; set; }

        

    }
    }
