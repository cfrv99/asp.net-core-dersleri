using EShopTest.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopTest.Helpers
{
    static public class CartStorage
    {
        static public void AddToCart(ISession session, Product product)
        {
            List<Product> cart;
            try
            {
                var sessionProducts = session.GetString("cart");
                cart = JsonConvert.DeserializeObject<List<Product>>(sessionProducts);
            }
            catch (Exception)
            {
                cart = new List<Product>();
            }
            cart.Add(product);
            session.SetString("cart", JsonConvert.SerializeObject(cart));
        }

        static public void RemoveFromCart(ISession session, Product product)
        {
            List<Product> cart;
            try
            {
                var sessionProducts = session.GetString("cart");
                cart = JsonConvert.DeserializeObject<List<Product>>(sessionProducts);
                var itemToRemove = cart.FirstOrDefault(x => x.Id == product.Id);
                cart.Remove(itemToRemove);
            }
            catch (Exception)
            {
                cart = new List<Product>();
            } 
            session.SetString("cart", JsonConvert.SerializeObject(cart));
        }

        static public IEnumerable<Product> GetCartProducts(ISession session)
        {
            List<Product> cart;
            try
            {
                var sessionProducts = session.GetString("cart");
                cart = JsonConvert.DeserializeObject<List<Product>>(sessionProducts);
            }
            catch (Exception)
            {
                cart = new List<Product>();
            }
            return cart;
        }

        static public void ClearCart(ISession session)
        {
            session.Remove("cart");
        }
    }
}
