using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTodoApp.Models.Entities;
using MyTodoApp.Models.TodoApp;
using MyTodoApp.Service;

namespace MyTodoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoApiController(ITodoService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
            => Ok(await service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            var todo = await service.GetByIdAsync(id);
            return todo == null ? NotFound() : Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo(Todo todo)
        {
            var created = await service.CreateAsync(todo);
            return CreatedAtAction(nameof(GetTodo), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, Todo updatedTodo)
        {
            var result = await service.UpdateAsync(id, updatedTodo);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var result = await service.DeleteAsync(id);
            return result ? NoContent() : NotFound();
        }
    }
};