using University.API.Model;

namespace University.API.Commands
{
    public interface ICourseCommands
    {
        Task Add(Course course);
    }
}
