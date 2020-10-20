using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebLab.DAL.Entities;
using WebLab.Extensions;
using WebLab.Models;

namespace WebLab.Services
{
    public class CartService : Cart
    {
        private string sessionKey = "cart";
        [JsonIgnore]
        ISession Session { get; set; }

        public static Cart GetCart(IServiceProvider sp)
        {
            var session = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;

            var cart = session?.Get<CartService>("cart") ?? new CartService();
            cart.Session = session;
            return cart;
        }
        public override void AddToCart(LegalService legalService)
        {
            base.AddToCart(legalService);
            Session?.Set<CartService>(sessionKey, this);
        }
        public override void RemoveFromCart(int id)
        {
            base.RemoveFromCart(id);
            Session?.Set<CartService>(sessionKey, this);
        }
        public override void ClearAll()
        {
            base.ClearAll();
            Session?.Set<CartService>(sessionKey, this);
        }
    }
}
