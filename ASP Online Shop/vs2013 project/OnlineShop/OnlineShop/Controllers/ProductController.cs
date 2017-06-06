using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        [HttpGet]
        public ActionResult Index()
        {
            ProductViewModel model = new ProductViewModel();
            using (var dbContext = new ApplicationDbContext())
            {
                model.Products = dbContext.Products.ToList();
            }
            return View(model);
        }

        //
        // GET: /Product/Details
        [HttpGet]
        public ActionResult Details(int productId)
        {
            ProductDetailsViewModel model = new ProductDetailsViewModel();
            using (var dbContext = new ApplicationDbContext())
            {
                model.Product = dbContext.Products.Find(productId);
            }
            return View(model);
        }
    }
}