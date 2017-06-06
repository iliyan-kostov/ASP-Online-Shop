using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class ProductViewModel
    {
        public ICollection<Product> Products { set; get; }
    }

    public class ProductDetailsViewModel
    {
        [Required]
        [DisplayName("Amount")]
        [Range(0, 100, ErrorMessage = "The {0} must be between {1} and {2}.")]
        public int Amount { set; get; }

        public Product Product { set; get; }
    }
}