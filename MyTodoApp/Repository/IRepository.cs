using MyTodoApp.Models.TodoApp;

namespace MyTodoApp.Repository
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodo();
        Task<Todo?> GetTodoByIdFromDb(int id);
        Task<Todo> CreateTodoFromDb(Todo todo);
        Task<bool> UpdateTodo(Todo updatedTodo);
        Task<bool> DeleteTodo(int id);
    }
}