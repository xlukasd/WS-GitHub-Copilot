using Microsoft.AspNetCore.Mvc;
using University.API.Commands;
using University.API.Model;
using University.API.Queries;

namespace University.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController(ICourseQuery courseQuery, ICourseCommands courseCommands) : ControllerBase
    {
        private ICourseQuery CourseQuery { get; } = courseQuery;
        private ICourseCommands CourseCommands { get; } = courseCommands;

        [HttpGet("all", Name = "GetAllCourses")]
        public IEnumerable<Course> GetAll()
        {
            return CourseQuery.GetAll();
        }

        [HttpPost("add", Name = "AddCourse")]
        public void Add([FromBody]Course course)
        {
            CourseCommands.Add(course);
        }
    }
}
