using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ToDoLogIn.Models;

namespace ToDoLogIn.Data
{
    public class TodoJsonData : ITodoData
    {
        private string todoFile = "todos.json";
        private IList<Todo> _todos;

        public TodoJsonData()
        {
            if (!File.Exists(todoFile))
            {
                Seed();
                WriteTodosToFile();
            }
            else
            {
                string content = File.ReadAllText(todoFile);
                _todos = JsonSerializer.Deserialize<List<Todo>>(content);
            }
        }
        
        public IList<Todo> GetTodos()
        {
            return new List<Todo>(_todos);
        }

        public void AddTodo(Todo todo)
        {
            int max = _todos.Max(todo1 => todo1.TodoId);
            todo.TodoId = (++max);
            _todos.Add(todo);
            WriteTodosToFile();
        }

        public void RemoveTodo(int todoId)
        {
            Todo toRemove = _todos.First(t => t.TodoId == todoId);
            _todos.Remove(toRemove);
            WriteTodosToFile();
        }

        public void Update(Todo todo)
        {
            Todo toUpdate = _todos.First(t => t.TodoId == todo.TodoId);
            toUpdate.IsCompleted = todo.IsCompleted;
            toUpdate.Title = todo.Title;
            WriteTodosToFile();
        }

        public Todo Get(int id)
        {
            return _todos.FirstOrDefault(t => t.TodoId == id);
        }

        private void WriteTodosToFile()
        {
            string todosAsJson = JsonSerializer.Serialize(_todos);
            File.WriteAllText(todoFile, todosAsJson);
        }

        private void Seed()
        {
            Todo[] ts =
            {
                new Todo()
                {
                    UserId = 1,
                    TodoId = 1,
                    Title = "Do dishes",
                    IsCompleted = false
                },
                new Todo()
                {
                    UserId = 1,
                    TodoId = 2,
                    Title = "Walk the dog",
                    IsCompleted = false
                },
                new Todo()
                {
                    UserId = 2,
                    TodoId = 3,
                    Title = "Do DNP homework",
                    IsCompleted = true
                },
                new Todo()
                {
                    UserId = 3,
                    TodoId = 4,
                    Title = "Eat breakfast",
                    IsCompleted = false
                },
                new Todo()
                {
                    UserId = 4,
                    TodoId = 5,
                    Title = "Mom lawn",
                    IsCompleted = true
                },
            };
            _todos = ts.ToList();
        }
    }
}