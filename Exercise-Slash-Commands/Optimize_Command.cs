using System.Data.SqlClient;
using Exercise_Slash_Commands.Help;

namespace Exercise_Slash_Commands
{
    internal class Optimize_Command
    {
        internal void Persist(IReadOnlyCollection<Course> courses)
        {
            foreach (var course in courses)
            {
                using var connection = new SqlConnection(GetConnectionString());
                connection.Open();

                using var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO Courses (Id, Name, Description, StartDate, EndDate) VALUES (@Id, @Name, @Description, @StartDate, @EndDate)";
                command.Parameters.AddWithValue("@Id", course.Id);
                command.Parameters.AddWithValue("@Name", course.Name);
                command.Parameters.AddWithValue("@Description", course.Description);
                command.Parameters.AddWithValue("@StartDate", course.StartDate);
                command.Parameters.AddWithValue("@EndDate", course.EndDate);

                command.ExecuteNonQuery();
            }
        }

        private static string GetConnectionString()
        {
            return "Data Source=.;Initial Catalog=Exercise-Slash-Commands;Integrated Security=True";
        }
    }
}
