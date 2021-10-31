using System;
using System.Collections.Generic;
using System.Linq;
using ToDoLogIn.Models;

namespace ToDoLogIn.Data.Impl
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
                    Domain = "via.dk",
                    Role = "Teacher",
                    Password = "123456",
                    BirthYear = 1986,
                    SecurityLevel = 4,
                    UserName = "Troels"
                },
                new User
                {
                    City = "Aarhus",
                    Domain = "hotmail.com",
                    Password = "654321",
                    Role = "Student",
                    BirthYear = 1998,
                    SecurityLevel = 2,
                    UserName = "Jakob"
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