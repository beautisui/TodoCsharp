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
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos() => Ok(await service.GetAllTodo());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            var todo = await service.GetTodoById(id);
            return todo == null ? NotFound() : Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo(Todo todo)
        {
            var created = await service.CreateTodo(todo);
            return CreatedAtAction(nameof(GetTodo), new { id = created.Id }, created);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateTodo(int id, Todo updatedTodo)
        {
            var result = await service.UpdateTodo(id, updatedTodo);
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var result = await service.DeleteTodo(id);
            return result ? NoContent() : NotFound();
        }
    }
};