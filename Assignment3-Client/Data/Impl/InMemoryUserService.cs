using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3_Client.Models;

namespace Assignment3_Client.Data.Impl
{
    public class InMemoryUserService:IUserService
    {
        private readonly List<User> _users;

        public InMemoryUserService()
        {
            _users = new[]
            {
                new User
                {
                    City = "Horsens",
                    Domain = "google.dk",
                    Role = "Admin",
                    Password = "123456",
                    BirthYear = 2001,
                    SecurityLevel = 3,
                    UserName = "Troels"
                },
                new User
                {
                    City = "Horsens",
                    Domain = "hotmail.com",
                    Password = "654321",
                    Role = "User",
                    BirthYear = 2000,
                    SecurityLevel = 2,
                    UserName = "Jakob"
                }
            }.ToList();
        }

        public Task<User> ValidateUser(string userName, string password)
        {
            User first = _users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
                throw new Exception("User not found.");
            if (!first.Password.Equals(password))
                throw new Exception("Incorrect password");
            return Task.FromResult(first);
        }
    }
}