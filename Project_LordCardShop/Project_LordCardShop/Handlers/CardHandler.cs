using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_LordCardShop.Factories;
using Project_LordCardShop.Models;
using Project_LordCardShop.Repositories;

namespace Project_LordCardShop.Handlers
{
    public class CardHandler
    {
        public static List<Card> GetAllCards()
        {
            return CardRepository.GetAllCards();
        }

        public static string InsertCard(string name, string priceStr, string desc, string type, string foilStr)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 5 || name.Length > 50)
                return "Name must be between 5 and 50 characters.";

            if (!double.TryParse(priceStr, out double price) || price < 10000)
                return "Price must be a number and greater or equal than 10000.";

            if (string.IsNullOrWhiteSpace(desc)) return "Description must not be empty.";
            if (type != "Spell" && type != "Monster") return "Type must be Spell or Monster.";
            if (foilStr != "Yes" && foilStr != "No") return "Foil must be Yes or No.";

            bool isFoil = (foilStr == "Yes");
            Card newCard = CardFactory.CreateCard(name, price, desc, type, isFoil);
            CardRepository.InsertCard(newCard);
            return "success";
        }

        public static string UpdateCard(int cardId, string name, string priceStr, string desc, string type, string foilStr)
        {
            bool isFoil = (foilStr == "Yes");
            Card cardToUpdate = CardRepository.GetCardById(cardId);
            if (cardToUpdate == null) return "Card not found!";

            cardToUpdate.CardName = name;
            cardToUpdate.CardPrice = double.Parse(priceStr);
            cardToUpdate.CardDesc = desc;
            cardToUpdate.CardType = type;
            cardToUpdate.IsFoil = isFoil ? new byte[] { 1 } : new byte[] { 0 };

            CardRepository.UpdateCard(cardToUpdate);
            return "success";
        }
    }
}