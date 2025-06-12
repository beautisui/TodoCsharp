using Microsoft.EntityFrameworkCore;
using MyTodoApp.Models.TodoApp;

namespace MyTodoApp.Models.Entities
{
    public class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options) 
    {
        public DbSet<Todo> Todos { get; set; }
    }
}