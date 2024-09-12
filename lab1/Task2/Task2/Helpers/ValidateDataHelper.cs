using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.Helpers
{
    public static class ValidateDataHelper
    {
        public static bool ValidateRegisterData(string name, string email, string login, string password, out AppUser? user)
        {
            user = null;
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (!IsValidPasswordLength(password))
            {
                return false;
            }

            user = new AppUser
            {
                Name = name,
                Email = email,
                Login = login,
                Password = password
            };
            return true;
        }

        public static bool IsValidPasswordLength(string password)
        {
            return password.Length >= 5;
        }
    }
}
