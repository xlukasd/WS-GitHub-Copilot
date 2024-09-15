using University.API.Model;

namespace University.API.Queries
{
    public interface IUserQueries
    {
        ICollection<User> GetAll();
    }
}
