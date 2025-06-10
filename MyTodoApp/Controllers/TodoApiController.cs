using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyTodoApp.Models;
using MyTodoApp.Models.TodoApp;

namespace MyTodoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoApiController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoApiController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/todoapi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            return await _context.Todos.ToListAsync();
        }

        // GET: api/todoapi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return todo;
        }

        // POST: api/todoapi
        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodo), new { id = todo.Id }, todo);
        }

        // PUT: api/todoapi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, Todo updatedTodo)
        {
            if (id != updatedTodo.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedTodo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Todos.Any(t => t.Id == id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/todoapi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
