using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;
using TodoList.Models;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly DataContext _context;

        public ToDoItemsController(DataContext context)
        {
            _context = context;
        }

        // Get all ToDoItems without CompletedDate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetIncompleteItems()
        {
            return await _context.ToDoItems.Where(item => item.CompletedDate == null).ToListAsync();
        }
        
        // Get ToDoItem by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(int id)
        {
            var item = await _context.ToDoItems.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // Post a new ToDoItem
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> CreateToDoItem(ToDoItem newItem)
        {
            _context.ToDoItems.Add(newItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToDoItem), new { id = newItem.Id }, newItem);
        }

        // Mark a ToDoItem as complete
        [HttpPost("{id}/complete")]
        public async Task<IActionResult> MarkAsComplete(int id)
        {
            var existingItem = await _context.ToDoItems.FindAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.IsCompleted = true;
            existingItem.CompletedDate = DateTime.Now;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
    

