using Microsoft.EntityFrameworkCore;
using ToDoLogIn.Models;

namespace ToDoLogIn.Persistence
{
    public class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // name of database
            optionsBuilder.UseSqlite("Data Source = TodoDb.db");
        }
    }
}