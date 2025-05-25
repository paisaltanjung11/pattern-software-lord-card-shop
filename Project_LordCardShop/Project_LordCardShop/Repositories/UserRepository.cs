using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_LordCardShop.Models;

namespace Project_LordCardShop.Repositories
{
    public class UserRepository
    {
        private static LordCardShopDBEntities db = new LordCardShopDBEntities();

        public static User GetUserByEmail(string email)
        {
            return db.Users.FirstOrDefault(u => u.UserEmail.Equals(email));
        }

        public static User GetUserByCredentials(string email, string password)
        {
            return db.Users.FirstOrDefault(u => u.UserEmail.Equals(email) && u.UserPassword.Equals(password));
        }

        public static void InsertUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static void UpdateUser(User updatedUser)
        {
            User existingUser = db.Users.Find(updatedUser.UserID);
            if (existingUser != null)
            {
                existingUser.UserName = updatedUser.UserName;
                existingUser.UserEmail = updatedUser.UserEmail;
                existingUser.UserGender = updatedUser.UserGender;
                existingUser.UserDOB = updatedUser.UserDOB;
                if (!string.IsNullOrEmpty(updatedUser.UserPassword))
                {
                    existingUser.UserPassword = updatedUser.UserPassword;
                }
                db.SaveChanges();
            }
        }
        public static List<User> GetAllCustomers()
        {
            return db.Users.Where(u => u.UserRole == "Customer").ToList();
        }
        public static User GetUserById(int id)
        {
            return db.Users.Find(id);
        }
    }
}