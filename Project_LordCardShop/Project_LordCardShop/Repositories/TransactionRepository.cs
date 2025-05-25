using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_LordCardShop.Models;

namespace Project_LordCardShop.Repositories
{
    public class TransactionRepository
    {
        private static LordCardShopDBEntities db = new LordCardShopDBEntities();

        // untuk checkout
        public static void CreateTransaction(TransactionHeader header, List<TransactionDetail> details)
        {
            db.TransactionHeaders.Add(header);
            db.SaveChanges();

            foreach (var detail in details)
            {
                detail.TransactionID = header.TransactionID;
            }
            db.TransactionDetails.AddRange(details);
            db.SaveChanges();
        }

        public static List<TransactionHeader> GetTransactionsByUserId(int userId)
        {
            return db.TransactionHeaders.Where(h => h.CustomerID == userId).ToList();
        }

        public static List<TransactionHeader> GetAllTransactions()
        {
            return db.TransactionHeaders.ToList();
        }


        public static TransactionHeader GetTransactionHeaderById(int transactionId)
        {
            return db.TransactionHeaders.Find(transactionId);
        }

        public static void UpdateTransactionStatus(int transactionId, string newStatus)
        {
            TransactionHeader header = GetTransactionHeaderById(transactionId);
            if (header != null)
            {
                header.Status = newStatus;
                db.SaveChanges();
            }
        }
        public static List<TransactionDetail> GetDetailsByTransactionId(int transactionId)
        {
            return db.TransactionDetails.Where(d => d.TransactionID == transactionId).ToList();
        }
    }
}