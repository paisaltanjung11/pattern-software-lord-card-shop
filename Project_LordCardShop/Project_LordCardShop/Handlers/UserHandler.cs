using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Project_LordCardShop.Factories;
using Project_LordCardShop.Models;
using Project_LordCardShop.Repositories;

namespace Project_LordCardShop.Handlers
{
    public class UserHandler
    {
        public static string RegisterUser(string name, string email, string password, string confirmPassword, string gender, string dobString)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 5 || name.Length > 30 || !Regex.IsMatch(name, @"^[a-zA-Z ]+$"))
                return "Username must be between 5-30 characters and alphabet with space only.";

            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
                return "Email must be a valid format (contains '@').";

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8 || !password.Any(char.IsLetter) || !password.Any(char.IsDigit))
                return "Password must be at least 8 characters and alphanumeric.";

            if (password != confirmPassword) return "Confirmation Password must be the same with password.";
            if (string.IsNullOrWhiteSpace(gender)) return "Gender must be chosen.";

            if (!DateTime.TryParse(dobString, out DateTime dob))
                return "Date of Birth must be a valid date.";

            if (UserRepository.GetUserByEmail(email) != null)
                return "Email is already registered.";

            User newUser = UserFactory.CreateUser(name, email, password, gender, dob);
            UserRepository.InsertUser(newUser);
            return "success";
        }

        public static User LoginUser(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password)) return null;
            return UserRepository.GetUserByCredentials(email, password);
        }

        public static string UpdateProfile(int userId, string name, string email, string gender, string dobString, string oldPassword, string newPassword, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 5 || name.Length > 30 || !Regex.IsMatch(name, @"^[a-zA-Z ]+$"))
                return "Username must be between 5-30 characters and alphabet with space only.";

            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
                return "Email must be a valid format (contains '@').";

            if (string.IsNullOrWhiteSpace(gender)) return "Gender must be chosen.";

            if (!DateTime.TryParse(dobString, out DateTime dob))
                return "Date of Birth must be a valid date.";

            User currentUser = UserRepository.GetUserById(userId);
            if (currentUser == null) return "User not found.";

            // user pgn gnti pw
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                if (currentUser.UserPassword != oldPassword) return "Old password is not correct.";
                if (newPassword.Length < 8 || !newPassword.Any(char.IsLetter) || !newPassword.Any(char.IsDigit))
                    return "New Password must be at least 8 characters and alphanumeric.";
                if (newPassword != confirmPassword) return "Confirmation password must match new password.";
                currentUser.UserPassword = newPassword;
            }

            // cek email ud dipake apa blm
            User existingEmailUser = UserRepository.GetUserByEmail(email);
            if (existingEmailUser != null && existingEmailUser.UserID != userId)
            {
                return "New email is already used by another user.";
            }

            currentUser.UserName = name;
            currentUser.UserEmail = email;
            currentUser.UserGender = gender;
            currentUser.UserDOB = dob;

            UserRepository.UpdateUser(currentUser);
            return "success";
        }
    }
}