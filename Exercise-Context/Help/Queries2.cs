using System.Data.SqlClient;

namespace Exercise_Context.Help
{
    public class QueriesForCourse(string connectionString)
    {
        public void Save(Course course)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Course (Name, Amount, StartDate, EndDate) VALUES (@Name, @Price, @StartDate, @EndDate)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", course.Name);
                command.Parameters.AddWithValue("@Amount", course.Amount);
                command.Parameters.AddWithValue("@StartDate", course.StartDate);
                command.Parameters.AddWithValue("@EndDate", course.EndDate);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void WriteHelloWorld()
        {
            Console.WriteLine("Hello world");
        }

        public ICollection<Course> GetAll()
        {
            List<Course> courses = new List<Course>();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Course";
                var command = new SqlCommand(query, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var course = new Course();
                    course.Id = Guid.Parse(reader["Id"].ToString());
                    course.Lecturer = Guid.Parse(reader["Lecturer"].ToString());
                    course.Name = reader["Name"].ToString();
                    course.Amount = decimal.Parse(reader["Amount"].ToString());
                    course.StartDate = DateTime.Parse(reader["StartDate"].ToString());
                    course.EndDate = DateTime.Parse(reader["EndDate"].ToString());
                    courses.Add(course);
                }
            }

            return courses;
        }

        public void Update(Course course)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Course SET Lecturer = @Lecturer, Name = @Name, Amount = @Amount, StartDate = @StartDate, EndDate = @EndDate WHERE Id = @Id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", course.Id);
                command.Parameters.AddWithValue("@Lecturer", course.Lecturer);
                command.Parameters.AddWithValue("@Name", course.Name);
                command.Parameters.AddWithValue("@Amount", course.Amount);
                command.Parameters.AddWithValue("@StartDate", course.StartDate);
                command.Parameters.AddWithValue("@EndDate", course.EndDate);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Course GetById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Course WHERE Id = @Id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                var reader = command.ExecuteReader();

                if (!reader.Read())
                {
                    return null;
                }

                var course = new Course
                {
                    Id = Guid.Parse(reader["Id"].ToString()),
                    Lecturer = Guid.Parse(reader["Lecturer"].ToString()),
                    Name = reader["Name"].ToString(),
                    Amount = decimal.Parse(reader["Amount"].ToString()),
                    StartDate = DateTime.Parse(reader["StartDate"].ToString()),
                    EndDate = DateTime.Parse(reader["EndDate"].ToString())
                };

                return course;
            }

            return null;
        }

        public List<Course> GetCoursesWithAmmountHigherThan(decimal amount)
        {
            List<Course> courses = new List<Course>();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Course WHERE Amount > @Amount";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Amount", amount);
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var course = new Course
                    {
                        Id = Guid.Parse(reader["Id"].ToString()),
                        Lecturer = Guid.Parse(reader["Lecturer"].ToString()),
                        Name = reader["Name"].ToString(),
                        Amount = decimal.Parse(reader["Amount"].ToString()),
                        StartDate = DateTime.Parse(reader["StartDate"].ToString()),
                        EndDate = DateTime.Parse(reader["EndDate"].ToString())
                    };
                    courses.Add(course);
                }
            }

            return courses;
        }

        public void WriteCurrentDateTime()
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
