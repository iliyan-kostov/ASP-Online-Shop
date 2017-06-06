using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class CartItemStruct
    {
        public CartItem CartItem { set; get; }
        public int ProductId { set; get; }
        public string ProductName { set; get; }
        public string ProductImageUrl { set; get; }
        public double ProductUnitPrice { set; get; }
    }

    public class CartViewModel
    {
        public bool AddingItemToCart { set; get; }
        public bool AddingItemToCartIsSuccessful { set; get; }

        public double TotalPurchaseValue {set; get; }

        public ICollection<CartItemStruct> CartItemStructs { set; get; }
    }
}