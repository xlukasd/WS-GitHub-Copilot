using University.API.Database;
using University.API.Model;

namespace University.API.Commands
{
    public class CourseCommands(UniversityContext universityContext) : ICourseCommands
    {
        private UniversityContext UniversityContext { get; } = universityContext;

        public async Task Add(Course course)
        {
            UniversityContext.Add(course);
            await UniversityContext.SaveChangesAsync();
        }
    }
}
