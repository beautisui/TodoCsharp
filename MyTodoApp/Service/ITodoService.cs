using MyTodoApp.Models.TodoApp;

namespace MyTodoApp.Service
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo?> GetByIdAsync(int id);
        Task<Todo> CreateAsync(Todo todo);
        Task<bool> UpdateAsync(int id, Todo updatedTodo);
        Task<bool> DeleteAsync(int id);
    }

}

