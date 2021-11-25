using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoLogIn.Models;
using ToDoLogIn.Persistence;

namespace ToDoLogIn.Data
{
    public class DatabaseDataRetriever : ITodoData
    {

        public DatabaseDataRetriever()
        {
            
        }

        public async Task<List<Todo>> GetTodos()
        {
            using TodoContext todoContext = new TodoContext();

            return todoContext.Todos.ToList();
        }

        public async Task AddTodo(Todo todoToAdd)
        {
            using TodoContext todoContext = new TodoContext();

            await todoContext.Todos.AddAsync(todoToAdd);
            await todoContext.SaveChangesAsync();
        }

        public async Task RemoveTodo(int todoId)
        {
            using TodoContext todoContext = new TodoContext();

            Todo toRemove = todoContext.Todos.FirstOrDefaultAsync(todo => todo.TodoId == todoId).Result;
            todoContext.Todos.Remove(toRemove);
            await todoContext.SaveChangesAsync();
        }

        public async Task Update(Todo todo)
        {
            using TodoContext todoContext = new TodoContext();

            todoContext.Todos.Update(todo);
            await todoContext.SaveChangesAsync();
        }

        public Todo Get(int id)
        {
            using TodoContext todoContext = new TodoContext();

            return todoContext.Todos.FirstOrDefaultAsync(todo => todo.TodoId == id).Result;
        }
    }
}