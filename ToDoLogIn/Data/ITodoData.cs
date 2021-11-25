using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoLogIn.Models;

namespace ToDoLogIn.Data
{
    public interface ITodoData
    {
        Task<List<Todo>> GetTodos();
        Task AddTodo(Todo todo);
        Task RemoveTodo(int todoId);
        Task Update(Todo todo);
        Todo Get(int id);
    }
}