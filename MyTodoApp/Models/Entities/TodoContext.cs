using Microsoft.EntityFrameworkCore;

namespace MyTodoApp.Models.Entities
{
    public class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options) 
    {
        public DbSet<Todo> Todos { get; set; }
    }
}