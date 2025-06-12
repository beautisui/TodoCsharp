using MyTodoApp.Models.TodoApp;

namespace MyTodoApp.Repository
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodoFromDb();
        Task<Todo?> GetTodoByIdFromDb(int id);
        Task<Todo> CreateTodoFromDb(Todo todo);
        Task<bool> UpdateTodoFromDb(Todo updatedTodo);
        Task<bool> DeleteTodoFromDb(int id);
    }
}