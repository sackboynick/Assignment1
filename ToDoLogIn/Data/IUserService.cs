using ToDoLogIn.Models;

namespace ToDoLogIn.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}