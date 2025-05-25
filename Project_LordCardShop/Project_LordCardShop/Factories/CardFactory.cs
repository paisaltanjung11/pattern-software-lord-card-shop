using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_LordCardShop.Models;

namespace Project_LordCardShop.Factories
{
    public class CardFactory
    {
        public static Card CreateCard(string name, double price, string desc, string type, bool isFoil)
        {
            return new Card
            {
                CardName = name,
                CardPrice = price,
                CardDesc = desc,
                CardType = type,
                IsFoil = isFoil ? new byte[] { 1 } : new byte[] { 0 }
            };
        }
    }
}