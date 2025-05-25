using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_LordCardShop.Models;
using Project_LordCardShop.Repositories;

namespace Project_LordCardShop.Handlers
{
    public class CartHandler
    {
        public static string AddToCart(int userId, int cardId, int quantity)
        {
            if (quantity <= 0) return "Quantity must be at least 1.";

            // cek apakah item sudah ada di cart
            Cart existingItem = CartRepository.GetCartItem(userId, cardId);
            if (existingItem != null)
            {
                // jika ada, tambahkan jumlah (quantity)
                CartRepository.UpdateCartItemQuantity(userId, cardId, quantity);
            }
            else
            {
                // klo blm ada, buat item baru
                Cart newCartItem = new Cart { UserID = userId, CardID = cardId, Quantity = quantity };
                CartRepository.AddToCart(newCartItem);
            }
            return "Card added to cart successfully!";
        }

        public static void ClearCart(int userId)
        {
            CartRepository.ClearCart(userId);
        }
    }
}