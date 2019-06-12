using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using async_todo.DAL;
using async_todo.DAL.Entities;
using async_todo.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace async_todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ITaskService _context;

        public ToDoController(ITaskService context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetAllItems()
        {
            return await _context.GetTasksAsync();
        }

        [HttpPost("{item}")]
        public async Task<Tasks> AddToDoItem([FromQuery]Tasks item)
        {
            return await _context.CreateTaskAsync(item);
        }

        [HttpPut("{item}")]
        public async Task<Tasks> UpdateToDoItem([FromBody]Tasks item)
        {
            return await _context.UpdateTaskAsync(item);
        }

        [HttpDelete("{item}")]
        public async Task<Tasks> Delete([FromQuery]Tasks item)
        {
            return await _context.DeleteTaskAsync(item);
        }
    }
}
