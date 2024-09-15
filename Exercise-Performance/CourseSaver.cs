using Exercise_Performance.Help;
using System.Data.SqlClient;

namespace Exercise_Performance
{
    public class CourseSaver
    {
        public static void SaveCourses(IEnumerable<Course> courses, string connectionString)
        {
            foreach (var course in courses)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                        INSERT INTO Courses (Id, DepartmentId, Lecturer, Name, Amount, StartDate, EndDate)
                        VALUES (@Id, @DepartmentId, @Lecturer, @Name, @Amount, @StartDate, @EndDate)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", course.Id);
                        command.Parameters.AddWithValue("@DepartmentId", course.DepartmentId);
                        command.Parameters.AddWithValue("@Lecturer", course.Lecturer);
                        command.Parameters.AddWithValue("@Name", course.Name);
                        command.Parameters.AddWithValue("@Amount", course.Amount);
                        command.Parameters.AddWithValue("@StartDate", course.StartDate);
                        command.Parameters.AddWithValue("@EndDate", course.EndDate);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }            
        }
    }
}
