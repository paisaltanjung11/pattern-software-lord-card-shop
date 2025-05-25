using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_LordCardShop.Models;
using System.Data.Entity; 

namespace Project_LordCardShop.Repositories
{
    public class CartRepository
    {
        private static LordCardShopDBEntities db = new LordCardShopDBEntities();

        public static List<Cart> GetCartsByUserId(int userId)
        {
            return db.Carts.Where(c => c.UserID == userId).ToList();
        }

        public static Cart GetCartItem(int userId, int cardId)
        {
            return db.Carts.FirstOrDefault(c => c.UserID == userId && c.CardID == cardId);
        }

        public static void AddToCart(Cart cartItem)
        {
            db.Carts.Add(cartItem);
            db.SaveChanges();
        }

        public static void UpdateCartItemQuantity(int userId, int cardId, int quantity)
        {
            Cart item = GetCartItem(userId, cardId);
            if (item != null)
            {
                item.Quantity += quantity;
                db.SaveChanges();
            }
        }

        // hapus smua item di cart
        public static void ClearCart(int userId)
        {
            List<Cart> userCarts = GetCartsByUserId(userId);
            db.Carts.RemoveRange(userCarts);
            db.SaveChanges();
        }
    }
}