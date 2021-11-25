using System.Threading.Tasks;
using Assignment3_Client.Models;

namespace Assignment3_Client.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
    }
}