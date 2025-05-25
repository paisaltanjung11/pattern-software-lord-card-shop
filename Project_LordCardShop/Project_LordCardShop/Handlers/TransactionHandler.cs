using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_LordCardShop.Factories;
using Project_LordCardShop.Models;
using Project_LordCardShop.Repositories;

namespace Project_LordCardShop.Handlers
{
    public class TransactionHandler
    {
        public static string Checkout(int userId)
        {
            List<Cart> userCartItems = CartRepository.GetCartsByUserId(userId);
            if (!userCartItems.Any())
            {
                return "Your cart is empty!";
            }

            TransactionHeader header = TransactionFactory.CreateHeader(userId);

            List<TransactionDetail> details = new List<TransactionDetail>();
            foreach (var item in userCartItems)
            {
                details.Add(TransactionFactory.CreateDetail((int)item.CardID, (int)item.Quantity));
            }

            TransactionRepository.CreateTransaction(header, details);

            CartRepository.ClearCart(userId); // delete cart klo checkout berhasil

            return "success";
        }

        public static void HandleTransaction(int transactionId)
        {
            TransactionRepository.UpdateTransactionStatus(transactionId, "Handled");
        }
    }
}