using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Online_Exam.Models
{
    public class Groups
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\OnlineExam.mdf;Integrated Security=True");
        [Required]//
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Description is Required")]
        public string Description {  get; set; }



        // public Users Users { get; set; }
        //[Required]
        // public ICollection<Students> Students { get; set; }=new HashSet<Students>();
        //public ICollection<Exams> Exams { get; set; }=new HashSet<Exams>();


        //Retrieve all records from a table
        public List<Groups> getData()
        {
            List<Groups> lstEmp = new List<Groups>();
            SqlDataAdapter apt = new SqlDataAdapter("select * from Group", con);
            DataSet ds = new DataSet();
            apt.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lstEmp.Add(new Groups
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    Name = dr["Name"].ToString(),
                    Description = dr["Description"].ToString(),
                   
                });
            }
            return lstEmp;
        }

        //Retrieve single record from a table
        public Groups getData(string Id)
        {
            Groups emp = new Groups();
            SqlCommand cmd = new SqlCommand("select * from Group where id='" + Id +"'", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    emp.Id = Convert.ToInt32(dr["Id"].ToString());
                    emp.Name = dr["Name"].ToString();
                    emp.Description = dr["Description"].ToString();
                    
                }
            }
            con.Close();
            return emp;
        }

        //Insert a record into a database table
        public bool insert(Groups Emp)
        {
            SqlCommand cmd = new SqlCommand("insert into Group values(@Name, @Description)", con);
           
            cmd.Parameters.AddWithValue("@Name", Emp.Name);
            cmd.Parameters.AddWithValue("@Description", Emp.Description);
            
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }

        //Update a record into a database table
        public bool update(Groups Emp)
        {
            SqlCommand cmd = new SqlCommand("update Group set Name=@name, Description=@Description where Id = @id", con);
           
            cmd.Parameters.AddWithValue("@name", Emp.Name);
            cmd.Parameters.AddWithValue("@Description", Emp.Description);
            cmd.Parameters.AddWithValue("@id", Emp.Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }
        //delete a record from a database table
        public bool delete(Groups Emp)
        {
            SqlCommand cmd = new SqlCommand("delete Group where Id = @id", con);
            cmd.Parameters.AddWithValue("@id", Emp.Id);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            return false;
        }


    }
}
