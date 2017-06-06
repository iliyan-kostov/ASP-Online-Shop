using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/
        public ActionResult Index()
        {
            var result = new CartViewModel() { AddingItemToCart = false, TotalPurchaseValue = 0 };
            if (Request.IsAuthenticated)
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    // Load user's cart contents from db to model:
                    {
                        var user = User.Identity.GetUserId();
                        var cartItems = (dbContext.CartItems.Where(
                            d => d.ApplicationUserId.Equals(user)
                            ).OrderBy(a => a.CartItemId).ToList());
                        var cartItemStructs = new List<CartItemStruct>();
                        foreach (var cartItem in cartItems)
                        {
                            cartItemStructs.Add(new CartItemStruct()
                            {
                                CartItem = cartItem,
                                ProductId = cartItem.ProductId,
                                ProductImageUrl = cartItem.Product.ImageUrl,
                                ProductName = cartItem.Product.Name,
                                ProductUnitPrice = cartItem.Product.UnitPrice
                            });
                            result.TotalPurchaseValue += cartItem.Product.UnitPrice * cartItem.Amount;
                        }
                        result.CartItemStructs = cartItemStructs;
                    }
                }
            }
            return View(result);
        }

        //
        // POST: /Cart/Add/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductDetailsViewModel model)
        {
            CartViewModel result = new CartViewModel() { AddingItemToCart = true };
            if (Request.IsAuthenticated)
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    try
                    {
                        dbContext.CartItems.Add(new CartItem()
                        {
                            ApplicationUserId = User.Identity.GetUserId(),
                            ProductId = Convert.ToInt32(Request["ProductId"]),
                            Amount = model.Amount
                        });
                        dbContext.SaveChanges();
                        result.AddingItemToCartIsSuccessful = true;
                    }
                    catch (Exception ex)
                    {
                        result.AddingItemToCartIsSuccessful = false;
                    }
                }
            }
            return View(result);
        }

        //
        // POST: /Cart/Reset/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reset()
        {
            if (Request.IsAuthenticated)
            {
                using (var dbContext = new ApplicationDbContext())
                {
                    // Load user's cart contents from db and perform the purchase:
                    {
                        var user = User.Identity.GetUserId();
                        var cartItems = (dbContext.CartItems.Where(
                            d => d.ApplicationUserId.Equals(user)
                            ).OrderBy(a => a.CartItemId).ToList());
                        foreach (var cartItem in cartItems)
                        {
                            dbContext.CartItems.Remove(cartItem);
                        }
                        dbContext.SaveChanges();
                    }
                }
            }
            return View();
        }
    }
}