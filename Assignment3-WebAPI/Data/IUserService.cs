using Assignment3_WebAPI.Models;

namespace Assignment3_WebAPI.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}