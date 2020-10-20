using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab.DAL.Entities;

namespace WebLab.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        public int Count 
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }

        public decimal TotalPrice 
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity * item.Value.LegalService.Price);
            }
        }

        public virtual void AddToCart(LegalService legalService)
        {
            if (Items.ContainsKey(legalService.LegalServiceId))
            {
                Items[legalService.LegalServiceId].Quantity++;
            }
            else
            {
                Items.Add(legalService.LegalServiceId, new CartItem { 
                    LegalService = legalService, 
                    Quantity = 1 });
            }
        }

        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }

    public class CartItem
    {
        public LegalService LegalService { get; set; }
        public int Quantity { get; set; }
    }
}
