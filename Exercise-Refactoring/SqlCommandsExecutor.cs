﻿using Exercise_Refactoring.Help;
using System.Data.SqlClient;

namespace Exercise_Refactoring
{
    public class SqlCommandsExecutor(string connectionString)
    {
        public void CreateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [User] (Id, UserName, HashedPassword, Salt) VALUES (@Id, @UserName, @HashedPassword, @Salt)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@HashedPassword", user.HashedPassword);
                command.Parameters.AddWithValue("@Salt", user.Salt);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public IReadOnlyCollection<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, UserName, HashedPassword, Salt FROM [User]";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        Id = reader.GetGuid(0),
                        UserName = reader.GetString(1),
                        HashedPassword = reader.GetString(2),
                        Salt = reader.GetString(3)
                    };

                    users.Add(user);
                }

                reader.Close();
            }

            return users;
        }

        public User GetUserById(Guid id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, UserName, HashedPassword, Salt FROM [User] WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    User user = new User
                    {
                        Id = reader.GetGuid(0),
                        UserName = reader.GetString(1),
                        HashedPassword = reader.GetString(2),
                        Salt = reader.GetString(3)
                    };

                    reader.Close();
                    return user;
                }
            }

            return null; // Return null if no user with the specified ID is found
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE [User] SET UserName = @UserName, HashedPassword = @HashedPassword, Salt = @Salt WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@UserName", user.UserName);
                command.Parameters.AddWithValue("@HashedPassword", user.HashedPassword);
                command.Parameters.AddWithValue("@Salt", user.Salt);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
