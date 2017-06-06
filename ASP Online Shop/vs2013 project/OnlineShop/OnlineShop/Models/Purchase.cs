using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Purchase
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Purchase")]
        public int PurchaseId { set; get; }

        [Required]
        [ForeignKey("Product")]
        [DisplayName("Product")]
        public int ProductId { set; get; }
        public virtual Product Product { set; get; } // navigation attribute

        [Required]
        [ForeignKey("ApplicationUser")]
        [DisplayName("Application User")]
        public string ApplicationUserId { set; get; }
        public virtual ApplicationUser ApplicationUser { set; get; } // navigation attribute

        [Required]
        [DisplayName("Amount")]
        public int Amount { set; get; }

        [Required]
        [DisplayName("Value")]
        public double Value { set; get; }

        [Required]
        [DisplayName("Date Time")]
        public DateTime DateTime { set; get; }
    }
}