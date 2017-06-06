using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class CartItem
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Cart Item")]
        public int CartItemId { set; get; }

        [Required]
        [ForeignKey("ApplicationUser")]
        [DisplayName("Application User")]
        public string ApplicationUserId { set; get; }
        public virtual ApplicationUser ApplicationUser { set; get; } // navigation attribute

        [Required]
        [ForeignKey("Product")]
        [DisplayName("Product")]
        public int ProductId { set; get; }
        public virtual Product Product { set; get; } // navigation attribute

        [Required]
        [DisplayName("Amount")]
        [Range(0.0, 100.0, ErrorMessage = "The {0} must be between {1} and {2}.")]
        public int Amount { set; get; }
    }
}