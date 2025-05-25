using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_LordCardShop.Models;

namespace Project_LordCardShop.Factories
{
    public class UserFactory
    {
        public static User CreateUser(string name, string email, string password, string gender, DateTime dob)
        {
            User newUser = new User
            {
                UserName = name,
                UserEmail = email,
                UserPassword = password,
                UserGender = gender,
                UserDOB = dob,
                UserRole = "Customer" // default roleny
            };
            return newUser;
        }
    }
}