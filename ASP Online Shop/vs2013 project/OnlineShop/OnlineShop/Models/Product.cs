using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class Product
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Product")]
        public int ProductId { set; get; }

        [Required]
        [DisplayName("Name")]
        public string Name { set; get; }

        [Required]
        [DisplayName("Unit Price")]
        public double UnitPrice { set; get; }

        [Required]
        [DisplayName("Image Url")]
        public string ImageUrl { set; get; }

        public virtual ICollection<Purchase> Purchases { set; get; } // navigation attribute
        public virtual ICollection<CartItem> CartItems { set; get; } // navigation attribute
    }
}