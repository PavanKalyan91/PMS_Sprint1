using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMSBO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PMSDAL
{
    public class DeptDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConn"].ToString());


        public int AddDepartmentDetails(DeptBO ObjDeptBO)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_AddDepartmentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", ObjDeptBO.Dept_ID);
            cmd.Parameters.AddWithValue("@DepartmentName", ObjDeptBO.Dept_Name);
            cmd.Parameters.AddWithValue("@DepartmentLocation", ObjDeptBO.Dept_Location);
            cmd.Parameters.AddWithValue("@DepartmentPhone", ObjDeptBO.Dept_Phone);


            int result = cmd.ExecuteNonQuery();

            con.Close();
            if (result == 0)
            {
                //throw new IdNotFoundException("ID already exist");
                Console.WriteLine("ID already Exists");
            }
            return result;
        }
        public int DeleteDepartmentDetails(DeptBO DD, string DeptID)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_DeleteDepartmentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", DeptID);
            int result = cmd.ExecuteNonQuery();

            con.Close();
            if (result == 0)
            {
                // throw new IdNotFoundException("ID doesn't exists");
                Console.WriteLine("ID doesnot Exists");
            }
            return result;

        }

        public int UpdateDepartmentDetails(DeptBO ObjDeptBO, string DeptID)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_UpdateDepartmentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DepartmentID", DeptID);
            cmd.Parameters.AddWithValue("@DepartmentName", ObjDeptBO.Dept_Name);
            cmd.Parameters.AddWithValue("@DepartmentLocation", ObjDeptBO.Dept_Location);
            cmd.Parameters.AddWithValue("@DepartmentPhone", ObjDeptBO.Dept_Phone);
            int result = cmd.ExecuteNonQuery();

            con.Close();
            if (result == 0)
            {
                // throw new IdNotFoundException("ID already exists");
                Console.WriteLine("ID doesnot Exists");
            }
            return result;

        }
        public int ShowDepartmentDetails(DeptBO DD)
        {


            con.Open();
            SqlCommand cmd = new SqlCommand("sp_GetAllDepartment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            int result = cmd.ExecuteNonQuery();

            con.Close();
            if (result == 0)
            {
                // throw new IdNotFoundException("ID doesn't exists");
                Console.WriteLine("ID doesnot Exists");
            }
            return result;

        }
    }
}
