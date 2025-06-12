using MyTodoApp.Models.TodoApp;
using MyTodoApp.Repository;

namespace MyTodoApp.Service
{
    public class TodoService(ITodoRepository repository) : ITodoService
    {
        public Task<IEnumerable<Todo>> GetAllAsync() => repository.GetAllAsync();
        public Task<Todo?> GetByIdAsync(int id) => repository.GetByIdAsync(id);
        public Task<Todo> CreateAsync(Todo todo) => repository.CreateAsync(todo);
        public Task<bool> UpdateAsync(int id, Todo updatedTodo) {
            updatedTodo.Id = id;
           return repository.UpdateTodo(updatedTodo);
        }
        public Task<bool> DeleteAsync(int id) => repository.DeleteTodo(id);
    }
};