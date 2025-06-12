using Microsoft.EntityFrameworkCore;
using MyTodoApp.Models.Entities;
using MyTodoApp.Models.TodoApp;

namespace MyTodoApp.Service
{
// TodoService.cs
    public class TodoService(TodoContext context) : ITodoService
    {
        public async Task<IEnumerable<Todo>> GetAllAsync() => await context.Todos.ToListAsync();
        public async Task<Todo?> GetByIdAsync(int id) => await context.Todos.FindAsync(id);

        public async Task<Todo> CreateAsync(Todo todo)
        {
            context.Todos.Add(todo);
            await context.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> UpdateAsync(int id, Todo updatedTodo)
        {
            updatedTodo.Id = id;
            context.Entry(updatedTodo).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var todo = await context.Todos.FindAsync(id);
            if (todo == null) return false;
            context.Todos.Remove(todo);
            await context.SaveChangesAsync();
            return true;
        }
    }
}

