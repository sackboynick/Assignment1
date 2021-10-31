using Assignment2_WebAPI.Models;

namespace Assignment2_WebAPI.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}