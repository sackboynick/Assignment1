using System.Threading.Tasks;
using Assignment2_Client.Models;

namespace Assignment2_Client.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
    }
}