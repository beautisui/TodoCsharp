using MyTodoApp.Models.TodoApp;
using MyTodoApp.Repository;

namespace MyTodoApp.Service
{
    public class TodoService(ITodoRepository repository) : ITodoService
    {
        public Task<IEnumerable<Todo>> GetAllTodo() => repository.GetAllTodo();
        public Task<Todo?> GetTodoById(int id) => repository.GetTodoByIdFromDb(id);
        public Task<Todo> CreateTodo(Todo todo) => repository.CreateTodoFromDb(todo);
        public Task<bool> UpdateTodo(int id, Todo updatedTodo) {
            updatedTodo.Id = id;
           return repository.UpdateTodo(updatedTodo);
        }
        public Task<bool> DeleteTodo(int id) => repository.DeleteTodo(id);
    }
};