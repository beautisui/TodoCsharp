using Microsoft.EntityFrameworkCore;
using MyTodoApp.Models.TodoApp;

namespace MyTodoApp.Models.TodoApp
{
    public class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options)
    {
        public DbSet<Todo> Todos { get; set; }
    }
}