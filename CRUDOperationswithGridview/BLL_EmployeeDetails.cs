using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CRUDOperationswithGridview
{
    public class BLL_EmployeeDetails
    {
        public static string Connectionstring()
        {
            string cstr;
            cstr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            return cstr;
        }
        public DataTable GetEmployeedetails(int EmployeeMasterID)
        {
            SqlConnection connetion = null;
            SqlCommand command = null;
            SqlDataAdapter sqlDA = null;
            DataTable dtEmployees = null;

            using (connetion = new SqlConnection(Connectionstring()))
            {
                command = connetion.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "USP_GetEmployeeDetails";
                command.Parameters.Add("@EmployeeMasterID", SqlDbType.Int).Value = EmployeeMasterID;
                sqlDA = new SqlDataAdapter(command);
                dtEmployees = new DataTable();
                sqlDA.Fill(dtEmployees);
            }
            return dtEmployees;
        }

        public string Add(int EmployeeMasterID, int EmployeeCode, string EmployeeName, string Designation, int Salary)
        {
            string message = string.Empty;
            SqlConnection connection = null;
            SqlCommand command = null;

            using (connection = new SqlConnection(Connectionstring()))
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[USP_INSERT_UPDATE_EMPLOYEEDETAILS]";
                command.Parameters.Add("@EmployeeMasterID", SqlDbType.Int).Value = EmployeeMasterID;
                command.Parameters.Add("@EmployeeCode", SqlDbType.Int).Value = EmployeeCode;
                command.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = EmployeeName;
                command.Parameters.Add("@Designation", SqlDbType.NVarChar).Value = Designation;
                command.Parameters.Add("@Salary", SqlDbType.Int).Value = Salary;
                command.Parameters.Add("@message", SqlDbType.NVarChar,250).Direction = ParameterDirection.Output;

                connection.Open();
                command.ExecuteNonQuery();
                message = command.Parameters["@message"].Value.ToString();
                connection.Close();
            }
            return message;
        }

        public string Delete(int EmployeeMasterID)
        {
            string message = string.Empty;
            SqlConnection connection = null;
            SqlCommand command = null;

            using (connection = new SqlConnection(Connectionstring()))
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[USP_DELETE_EMPLOYEEDETAILS]";
                command.Parameters.Add("@EmployeeMasterID", SqlDbType.Int).Value = EmployeeMasterID;                
                command.Parameters.Add("@message", SqlDbType.NVarChar, 250).Direction = ParameterDirection.Output;

                connection.Open();
                command.ExecuteNonQuery();
                message = command.Parameters["@message"].Value.ToString();
                connection.Close();
            }
            return message;
        }
    }
}