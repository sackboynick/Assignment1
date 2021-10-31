using System;
using System.Collections.Generic;
using System.Linq;
using Assignment2_WebAPI.Models;

namespace Assignment2_WebAPI.Data.Impl
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
                    UserName = "Nicola"
                },
                new User
                {
                    City = "Horsens",
                    Domain = "hotmail.com",
                    Password = "654321",
                    Role = "User",
                    BirthYear = 2000,
                    SecurityLevel = 2,
                    UserName = "Hans"
                }
            }.ToList();
        }

        public User ValidateUser(string userName, string password)
        {
            User first = _users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
                throw new Exception("User not found.");
            if (!first.Password.Equals(password))
                throw new Exception("Incorrect password");
            return first;
        }
    }
}