using University.API.Model;

namespace University.API.Queries
{
    public interface ICourseQuery
    {
        ICollection<Course> GetAll();
    }
}
