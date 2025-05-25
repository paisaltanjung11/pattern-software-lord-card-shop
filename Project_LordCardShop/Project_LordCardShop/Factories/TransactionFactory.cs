using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_LordCardShop.Models;

namespace Project_LordCardShop.Factories
{
    public class TransactionFactory
    {
        public static TransactionHeader CreateHeader(int customerId)
        {
            return new TransactionHeader
            {
                CustomerID = customerId,
                TransactionDate = DateTime.Now,
                Status = "Unhandled"
            };
        }
        public static TransactionDetail CreateDetail(int cardId, int quantity)
        {
            return new TransactionDetail
            {
                CardID = cardId,
                Quantity = quantity
            };
        }
    }
}