using MyTodoApp.Models.Entities;

namespace MyTodoApp.Service
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllTodo();
        Task<Todo?> GetTodoById(int id);
        Task<Todo> CreateTodo(Todo todo);
        Task<bool> UpdateTodo(int id, Todo updatedTodo);
        Task<bool> DeleteTodo(int id);
    }

}

