using University.API.Database;
using University.API.Model;

namespace University.API.Queries
{
    internal class CourseQuery(UniversityContext universityContext) : ICourseQuery
    {
        private UniversityContext UniversityContext { get; } = universityContext;

        public ICollection<Course> GetAll()
        {
            return [.. UniversityContext.Courses];
        }
    }
}
