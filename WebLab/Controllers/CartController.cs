using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebLab.DAL.Data;
using WebLab.Extensions;
using WebLab.Models;

namespace WebLab.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext context;
        private string cartKey = "cart";
        private Cart _cart;

        public CartController(ApplicationDbContext dbContext, Cart cart)
        {
            context = dbContext;
            _cart = cart;
        }
        public IActionResult Index()
        {
            _cart = HttpContext.Session.Get<Cart>(cartKey);
            return View(_cart.Items.Values);
        }

        [Authorize]
        public IActionResult Add(int id, string returnUrl)
        {
            _cart = HttpContext.Session.Get<Cart>(cartKey);
            var item = context.LegalServices.Find(id);
            if (item != null)
            {
                _cart.AddToCart(item);
                HttpContext.Session.Set<Cart>(cartKey, _cart);
            }
            return Redirect(returnUrl);
        }
    }
}
