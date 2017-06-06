using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace OnlineShop.Controllers
{
    public class PurchaseController : Controller
    {
        //
        // POST: /Purchase/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index()
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
                        DateTime now = DateTime.Now;
                        foreach (var cartItem in cartItems)
                        {
                            dbContext.Purchases.Add(new Purchase()
                            {
                                ProductId = cartItem.ProductId,
                                ApplicationUserId = User.Identity.GetUserId(),
                                Amount = cartItem.Amount,
                                Value = cartItem.Amount * cartItem.Product.UnitPrice,
                                DateTime = now
                            });
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