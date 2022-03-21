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
    public class EmpDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConn"].ToString());

        public int AddEmployeeDetails(EmpBO ObjEmpBO)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_AddEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", ObjEmpBO.Emp_ID);
                cmd.Parameters.AddWithValue("@EDepartmentID", ObjEmpBO.Dept_ID);
                cmd.Parameters.AddWithValue("@EmployeeFirstName", ObjEmpBO.Emp_FirstName);
                cmd.Parameters.AddWithValue("@EmployeeMiddleName", ObjEmpBO.Emp_MiddleName);
                cmd.Parameters.AddWithValue("@EmployeeLastName", ObjEmpBO.Emp_LastName);
                cmd.Parameters.AddWithValue("@EmployeeAddress", ObjEmpBO.Emp_Address);
                cmd.Parameters.AddWithValue("@EmployeeDOB", ObjEmpBO.Emp_DOB);
                cmd.Parameters.AddWithValue("@EmployeeDOJ", ObjEmpBO.Emp_DOJ);
                cmd.Parameters.AddWithValue("@EmployeeQualification", ObjEmpBO.Emp_Qua);

                con.Open();
                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result == 0)
                {
                    //throw new IdNotFoundException("Employee ID already exists");
                    Console.WriteLine("Employee ID already exists");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
        public int DeleteEmployeeDetails(EmpBO DE, string EmpID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_DeleteEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", EmpID);
                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result == 0)
                {
                    // throw new IdNotFoundException("Employee ID doesn't exists");
                    Console.WriteLine("Employee ID doesn't exists");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }


        public int UpdateEmployeeDetails(EmpBO ObjEmpBO, string EmpID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_UpdateEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", EmpID);
                cmd.Parameters.AddWithValue("@EDepartmentID", ObjEmpBO.Dept_ID);
                cmd.Parameters.AddWithValue("@EmployeeFirstName", ObjEmpBO.Emp_FirstName);
                cmd.Parameters.AddWithValue("@EmployeeMiddleName", ObjEmpBO.Emp_MiddleName);
                cmd.Parameters.AddWithValue("@EmployeeLastName", ObjEmpBO.Emp_LastName);
                cmd.Parameters.AddWithValue("@EmployeeAddress", ObjEmpBO.Emp_Address);
                cmd.Parameters.AddWithValue("@EmployeeDOB", ObjEmpBO.Emp_DOB);
                cmd.Parameters.AddWithValue("@EmployeeDOJ", ObjEmpBO.Emp_DOJ);
                cmd.Parameters.AddWithValue("@EmployeeQualification", ObjEmpBO.Emp_Qua);
                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result == 0)
                {
                    //  throw new IdNotFoundException("Employee ID already exists");
                    Console.WriteLine("Employee ID doesn't exists");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }


        public int ShowEmployeeDetails(EmpBO DE)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                int result = cmd.ExecuteNonQuery();

                con.Close();
                if (result == 0)
                {
                    //throw new IdNotFoundException("Employee ID doesn't exists");
                    Console.WriteLine("Employee ID doesn't exists");
                }
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
