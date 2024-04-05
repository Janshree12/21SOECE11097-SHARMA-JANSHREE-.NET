using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Exam.Models
{
    public class User
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\.NET\database\database\App_Data\OnlineExam.mdf;Integrated Security=True");

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }

        // Retrieve all records from a table
        public List<User> getData()
        {
            List<User> lstEmp = new List<User>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from User", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstEmp.Add(new User
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    Username = dr["Username"].ToString(),
                    Name = dr["Name"].ToString(),
                    Role = dr["Role"].ToString(),
                });
            }
            return lstEmp;
        }


        //Retrieve single record from a table
        public User getData(string Id)
        {
            User emp = new User();
            SqlCommand cmd = new SqlCommand("select * from User where id='" + Id + "'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Id = Convert.ToInt32(dr["Id"].ToString());
                    emp.Username = dr["Username"].ToString();
                    emp.Name = dr["Name"].ToString();
                    emp.Password = dr["Password"].ToString();
                }
            }
            con.Close();
            return emp;
        }


        //Insert a record into a database table
        public bool insert(User Emp)
        {
            SqlCommand cmd = new SqlCommand("insert into User values(@Username, @Name, @Password,@Role)", con);

            cmd.Parameters.AddWithValue("@Username", Emp.Username);
            cmd.Parameters.AddWithValue("@Name", Emp.Name);
            cmd.Parameters.AddWithValue("@Password", Emp.Password);
            cmd.Parameters.AddWithValue("@Role", Emp.Role);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }

        //Update a record into a database table
        public bool update(User Emp)
        {
            SqlCommand cmd = new SqlCommand("update User set Username=@Username, Name = @Name, Password = @Password, Role=@Role where Id = @Id", con);

            cmd.Parameters.AddWithValue("@Username", Emp.Username);
            cmd.Parameters.AddWithValue("@Email", Emp.Name);
            cmd.Parameters.AddWithValue("@Password", Emp.Password);
            cmd.Parameters.AddWithValue("@Role", Emp.Role);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }

        //delete a record from a database table
        /* public bool delete(User Emp)
         {
             SqlCommand cmd = new SqlCommand("delete User where Id = @Id", con);
             cmd.Parameters.AddWithValue("@Id", Emp.Id);
             con.Open();
             int i = cmd.ExecuteNonQuery();
             if (i >= 1)
             {
                 return true;
             }
             return false;
         }*/
    }
}

