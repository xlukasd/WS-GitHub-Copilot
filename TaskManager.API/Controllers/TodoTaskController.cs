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
            var random = _context.TodoTask.Where(x => x.Description.Replace('s', 'x').Contains('x')).ToList();

            var task = _context.TodoTask.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpGet(template: "filter", Name = "GetTasksWithDescription")]
        public IEnumerable<TodoTask> GetTasksWithDescription([FromQuery]char replace, [FromQuery] char replaceWith, [FromQuery] string mustContain)
        {
            var result = _context.TodoTask.Where(x => x.Description.Replace(replace, replaceWith).Contains(mustContain)).ToList();

            return result;
        }

        [HttpGet(template: "user/{userId:guid}", Name = "GetTasksOfUser")]
        public IEnumerable<TodoTask> GetTasks(Guid userId)
        {
            return [.. _context.TodoTask.Where(task => task.UserId == userId)];
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

            _context.TodoTask.Add(task);
            _context.SaveChanges();

            return CreatedAtRoute("GetTaskById", new { id = task.Id }, task);
        }        
    }
}
