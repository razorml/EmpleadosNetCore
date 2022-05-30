using Empleados.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Empleados.Repositories
{
    public class EmployeeRepositories
    {
        private readonly IConfiguration _configuration;

        public EmployeeRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Employees> LoadListEmployees()
        {
            List<Employees> lsEmployees = new List<Employees>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using (SqlCommand cmd = new SqlCommand("SpGetAllEmployee", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employees obj = new Employees();
                    obj.EmployeeId = (int)dt.Rows[i]["EmployeeId"];
                    obj.Name = dt.Rows[i]["Name"].ToString();
                    obj.Email = dt.Rows[i]["Email"].ToString();
                    obj.Telephone = dt.Rows[i]["Telephone"].ToString();
                    obj.Username = dt.Rows[i]["Username"].ToString();
                    obj.CompanyId =  (int)dt.Rows[i]["CompanyId"];
                    obj.RoleId = (int)dt.Rows[i]["RoleId"];
                    obj.StatusId = (int)dt.Rows[i]["StatusId"];
                    obj.CreatedOn = (DateTime)dt.Rows[i]["CreatedOn"];
                    obj.UpdatedOn = (DateTime)dt.Rows[i]["UpdatedOn"];
                    obj.DeletedOn = (DateTime)dt.Rows[i]["DeletedOn"];
                    obj.Fax = dt.Rows[i]["Fax"].ToString();
                    lsEmployees.Add(obj);
                }
                con.Close();
            }
            return lsEmployees;
        }

        public List<Employees> LoadListEmployeeId(int EmployeeId)
        {
            List<Employees> lsEmployees = new List<Employees>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using (SqlCommand cmd = new SqlCommand("SpGetEmployeeId", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmployeeId", SqlDbType.VarChar).Value = EmployeeId;
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employees obj = new Employees();
                    obj.EmployeeId = (int)dt.Rows[i]["EmployeeId"];
                    obj.Name = dt.Rows[i]["Name"].ToString();
                    obj.Email = dt.Rows[i]["Email"].ToString();
                    obj.Telephone = dt.Rows[i]["Telephone"].ToString();
                    obj.Username = dt.Rows[i]["Username"].ToString();
                    obj.CompanyId = (int)dt.Rows[i]["CompanyId"];
                    obj.RoleId = (int)dt.Rows[i]["RoleId"];
                    obj.StatusId = (int)dt.Rows[i]["StatusId"];
                    obj.CreatedOn = (DateTime)dt.Rows[i]["CreatedOn"];
                    obj.UpdatedOn = (DateTime)dt.Rows[i]["UpdatedOn"];
                    obj.DeletedOn = (DateTime)dt.Rows[i]["DeletedOn"];
                    obj.Fax = dt.Rows[i]["Fax"].ToString();
                    lsEmployees.Add(obj);
                }
                con.Close();
            }
            return lsEmployees;
        }

        public List<Employees> CreateEmployee(Employees Employees)
        {
            List<Employees> lsEmployees = new List<Employees>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using (SqlCommand cmd = new SqlCommand("SpInsertEmployee", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CompanyId", SqlDbType.VarChar).Value = Employees.CompanyId;
                cmd.Parameters.Add("@CreatedOn", SqlDbType.VarChar).Value = Employees.CreatedOn;
                cmd.Parameters.Add("@DeletedOn", SqlDbType.VarChar).Value = Employees.DeletedOn;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Employees.Email;
                cmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = Employees.Fax;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Employees.Name;
                cmd.Parameters.Add("@Lastlogin", SqlDbType.VarChar).Value = Employees.Lastlogin;
                cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = Employees.Password;
                cmd.Parameters.Add("@PortalId", SqlDbType.VarChar).Value = Employees.PortalId;
                cmd.Parameters.Add("@RoleId", SqlDbType.VarChar).Value = Employees.RoleId;
                cmd.Parameters.Add("@StatusId", SqlDbType.VarChar).Value = Employees.StatusId;
                cmd.Parameters.Add("@Telephone", SqlDbType.VarChar).Value = Employees.Telephone;
                cmd.Parameters.Add("@UpdatedOn", SqlDbType.VarChar).Value = Employees.UpdatedOn;
                cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = Employees.Username;
                con.Open();
                cmd.ExecuteNonQuery();
                lsEmployees = LoadListEmployees();
                con.Close();
            }
            return lsEmployees;
        }

        public List<Employees> DeleteEmployee(int EmployeeId)
        {
            List<Employees> lsEmployees = new List<Employees>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using (SqlCommand cmd = new SqlCommand("SpDeleteEmployee", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmployeeId", SqlDbType.VarChar).Value = EmployeeId;
                con.Open();
                cmd.ExecuteNonQuery();
                lsEmployees = LoadListEmployees();
                con.Close();
            }
            return lsEmployees;
        }

        public List<Employees> UpdateEmployee(int idEmployee, string userName)
        {
            List<Employees> lsEmployees = new List<Employees>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            using (SqlCommand cmd = new SqlCommand("SpUpdateEmployee", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdEmployee", SqlDbType.VarChar).Value = idEmployee;
                cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = userName;
                con.Open();
                cmd.ExecuteNonQuery();
                lsEmployees = LoadListEmployeeId(idEmployee);
                con.Close();
            }
            return lsEmployees;
        }
    }
}
