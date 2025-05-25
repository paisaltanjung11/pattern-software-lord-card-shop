using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_LordCardShop.Models;

namespace Project_LordCardShop.Repositories
{
    public class CardRepository
    {
        private static LordCardShopDBEntities db = new LordCardShopDBEntities();

        public static List<Card> GetAllCards()
        {
            return db.Cards.ToList();
        }

        public static Card GetCardById(int id)
        {
            return db.Cards.Find(id);
        }

        public static void InsertCard(Card card)
        {
            db.Cards.Add(card);
            db.SaveChanges();
        }

        public static void UpdateCard(Card updatedCard)
        {
            Card existingCard = db.Cards.Find(updatedCard.CardID);
            if (existingCard != null)
            {
                existingCard.CardName = updatedCard.CardName;
                existingCard.CardPrice = updatedCard.CardPrice;
                existingCard.CardDesc = updatedCard.CardDesc;
                existingCard.CardType = updatedCard.CardType;
                existingCard.IsFoil = updatedCard.IsFoil;
                db.SaveChanges();
            }
        }
        public static void DeleteCard(int id)
        {
            Card card = db.Cards.Find(id);
            if (card != null)
            {
                db.Cards.Remove(card);
                db.SaveChanges();
            }
        }
        public static List<Card> SearchCardsByName(string name)
        {
            return db.Cards.Where(c => c.CardName.Contains(name)).ToList();
        }
    }
}