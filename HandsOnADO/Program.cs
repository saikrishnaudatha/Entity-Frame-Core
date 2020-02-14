using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace HandsOnADO
{
    class Program
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0HNC64M\SQLEXPRESS;Initial Catalog=SampleDb;User ID=sa;Password=pass@word");
        SqlCommand cmd = null;
        public void Add()
        {
            try
            {
                cmd = new SqlCommand("Insert into project1 values(@id,@pname,@sdate,@edate)", con);
                cmd.Parameters.AddWithValue("@id", "P0007");
                cmd.Parameters.AddWithValue("@pname", "Boing");
                cmd.Parameters.AddWithValue("@sdate", DateTime.Parse("12.2.2019"));
                cmd.Parameters.AddWithValue("@edate", DateTime.Parse("12.12.2020"));
                con.Open();//open connection
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)

            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();//close connection
            }
        }
        public void GetProjectById(string pid)
        {
            try
            {
                cmd = new SqlCommand("Select * from project1 where Pid=@pid", con);
                cmd.Parameters.AddWithValue("@pid",pid);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Console.WriteLine("ID:{0} Name:{ 1} SDate:{2} EDate:{3}",
                                        dr["pid"],dr["pname"], dr["sdate"], dr["edate"]);
                }
                else
                    Console.WriteLine("Invalid Project Id");
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void GetAllProjects()
        {
            try { 
            cmd = new SqlCommand("Select * from project1 ", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    Console.WriteLine("ID:{0} Name:{ 1} SDate:{2} EDate:{3}",
                                        dr["id"], dr["pname"], dr["sdate"], dr["edate"]);
                }
            }
        }
        catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
}
static void Main(string[] args)
        {
            Program obj = new Program();
           // obj.Add();
            //obj.GetProjectById("P0005");
            obj.GetAllProjects();
            Console.ReadKey();
            
        }
    }
}

