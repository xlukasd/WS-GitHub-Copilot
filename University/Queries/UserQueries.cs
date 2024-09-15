using University.API.Database;
using University.API.Model;

namespace University.API.Queries
{
    internal class UserQueries(UniversityContext universityContext) : IUserQueries
    {
        private UniversityContext UniversityContext { get; } = universityContext;

        public ICollection<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
