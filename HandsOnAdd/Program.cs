using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HandsOnAdd
{
    class Program
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0HNC64M\SQLEXPRESS;Initial Catalog=SampleDb;User ID=sa;Password=pass@word");
        SqlCommand cmd = null;

        public void Add(string id, string name, int price, int stock)
        {
            try
            {
                cmd = new SqlCommand("Insert into Product values(@id,@name,@price,@stock)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@stock", stock);
                con.Open();  //Open Connection
                cmd.ExecuteNonQuery(); // Executes dml queries
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close(); //Closes Connection
            }
        }
        //public void Add()
        //{
        //    try
        //    {
        //        cmd = new SqlCommand("Insert into Product values(@id,@name,@price,@stock)", con);
        //        //Passing values to parameters
        //        cmd.Parameters.AddWithValue("@id", "P3");
        //        cmd.Parameters.AddWithValue("@name", "electronics");
        //        cmd.Parameters.AddWithValue("@price", 3500);
        //        cmd.Parameters.AddWithValue("@stock", 34);
        //        con.Open();  //Open Connection
        //        cmd.ExecuteNonQuery(); // Executes dml queries
        //    }

        //    catch (SqlException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close(); //Closes Connection
        //    }
        //}




        public void GetProductById(string id)
        {
            try
            {
                cmd = new SqlCommand("select * from product where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();  //Executes select statement
                if (dr.HasRows) //Checks row's Existence 
                {
                    //Read records in datareader
                    dr.Read();  //Reads only one record 
                    Console.WriteLine("ID :{0} Name:{1} Price:{2} Stock:{3}", dr["id"], dr["name"], dr["price"], dr["stock"]);
                }
                else
                    Console.WriteLine("Invalid Product ID");
            }

            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close(); //Closes Connection
            }

        }

        public void GetAllProducts()
        {
            try
            {
                cmd = new SqlCommand("select * from product", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows) //Checks row's Existence 
                {
                    //Read records in datareader
                    while (dr.Read())  //Reads until it becomes false
                    {
                        Console.WriteLine("ID :{0} Name:{1} Price:{2} Stock:{3}", dr["id"], dr["name"], dr["price"], dr["stock"]);
                    }
                }
                else
                    Console.WriteLine("Table Empty");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close(); //Closes Connection
            }

        }


        public void Delete(string id)
        {
            try
            {
                cmd = new SqlCommand("delete from product where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();

            }

            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close(); //Closes Connection
            }

        }

        public void Update(string id, int price, int stock)
        {
            try
            {
                cmd = new SqlCommand("update product set price=@price, stock=@stock where id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@stock", stock);
                con.Open();  //Open Connection
                cmd.ExecuteNonQuery(); // Executes dml queries
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close(); //Closes Connection
            }
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            //obj.Add("p5","asd",423,456);
            //obj.Add("p6", "das", 1234, 4556);
            //obj.GetProductById("P3");
            //obj.GetAllProducts();
            // obj.Delete("P2");
            obj.Update("p5", 123, 456);
            obj.GetAllProducts();
            Console.ReadKey();
        }
    }
}
