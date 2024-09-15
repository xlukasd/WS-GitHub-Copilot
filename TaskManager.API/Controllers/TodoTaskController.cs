using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Contract;
using TaskManager.API.Exception;
using TaskManager.API.Validators;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoTaskController(TaskManagementDbContext context) : ControllerBase
    {
        private readonly TaskManagementDbContext _context = context;

        [HttpGet("{id}", Name = "GetTaskById")]
        public IActionResult GetTaskById(Guid id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpGet(template: "user/{userId:guid}", Name = "GetTasksOfUser")]
        public IEnumerable<TodoTask> GetTasks(Guid userId)
        {
            return [.. _context.Tasks.Where(task => task.UserId == userId)];
        }

        [HttpPost(Name = "CreateTask")]
        public IActionResult CreateTask([FromBody] TodoTaskDTO taskDto)
        {
            try 
            {
                TodoTaskDTOValidator.EnsureValid(taskDto);
            }
            catch (TaskValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            TodoTask task = new()
            {
                Id = Guid.NewGuid(),
                UserId = taskDto.UserId,
                Title = taskDto.Title,
                Description = taskDto.Description,
                CreatedDate = DateTime.UtcNow,
                DueDate = taskDto.DueDate
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();

            return CreatedAtRoute("GetTaskById", new { id = task.Id }, task);
        }        
    }
}
