using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using async_todo.Models;
using Microsoft.EntityFrameworkCore;

namespace async_todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoDbContext _context;

        public ToDoController(ToDoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetAllItems()
        {
            return await _context.Tasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTodoItem(int id)
        {
            var todoItem = await _context.Tasks.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpPost("{item}")]
        public async Task<ActionResult<Tasks>> AddToDoItem([FromBody]Tasks item)
        {
            _context.Tasks.AddAsync(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        }

        [HttpPut("{item}")]
        public async Task<IActionResult> UpdateToDoItem(Tasks item)
        {
            var temp = _context.Tasks.First<Tasks>(t => t.Id == item.Id);
            temp.Completed = item.Completed;


            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
