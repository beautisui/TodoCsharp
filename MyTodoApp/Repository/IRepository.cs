using MyTodoApp.Models.TodoApp;

namespace MyTodoApp.Repository
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo?> GetByIdAsync(int id);
        Task<Todo> CreateAsync(Todo todo);
        Task<bool> UpdateTodo(Todo updatedTodo);
        Task<bool> DeleteTodo(int id);
    }
}