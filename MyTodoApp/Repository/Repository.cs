using Microsoft.EntityFrameworkCore;
using MyTodoApp.Models.TodoApp;
using MyTodoApp.Models.Entities;

namespace MyTodoApp.Repository
{
    public class TodoRepository(TodoContext context) : ITodoRepository
    {
        public async Task<IEnumerable<Todo>> GetAllTodo() => await context.Todos.ToListAsync();

        public async Task<Todo?> GetTodoByIdFromDb(int id) => await context.Todos.FindAsync(id);

        public async Task<Todo> CreateTodoFromDb(Todo todo)
        {
            context.Todos.Add(todo);
            await context.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> UpdateTodo(Todo updatedTodo)
        {
            context.Entry(updatedTodo).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTodo(int id)
        {
            var todo = await context.Todos.FindAsync(id);
            if (todo == null) return false;
            context.Todos.Remove(todo);
            await context.SaveChangesAsync();
            return true;
        }
    }
}