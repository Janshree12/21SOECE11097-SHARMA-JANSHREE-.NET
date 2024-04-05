using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Online_Exam.Models
{
    public class Students
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.NET\database\database\App_Data\OnlineExam.mdf;Integrated Security=True";

        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        public List<Students> GetData()
        {
            List<Students> studentsList = new List<Students>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Student";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Students student = new Students
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Username = reader["Username"].ToString(),
                            Name = reader["Name"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                        studentsList.Add(student);
                    }
                }
            }
            return studentsList;
        }

        public Students GetData(int id)
        {
            Students student = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Student WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        student = new Students
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Username = reader["Username"].ToString(),
                            Name = reader["Name"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                }
            }
            return student;
        }

        public bool Insert(Students student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Student (Username, Name, Password, Role) VALUES (@Username, @Name, @Password, @Role)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", student.Username);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Password", student.Password);
                    command.Parameters.AddWithValue("@Role", student.Role);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool Update(Students student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Student SET Username = @Username, Name = @Name, Password = @Password, Role = @Role WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", student.Username);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@Password", student.Password);
                    command.Parameters.AddWithValue("@Role", student.Role);
                    command.Parameters.AddWithValue("@Id", student.Id);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
