using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.ViewModel;
using System.Data.SqlClient;
using System.Data;
 
namespace WebApplication4.Models
{
    public class DepartmentDb
    {
        private DbConfig db = new DbConfig();

        public List<Department> GetAllDepartments()
        {
            SqlCommand cmd = new SqlCommand("sp_department", db.Sql);
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue("@action", "select");

            SqlParameter sqlParameter = new SqlParameter();

            sqlParameter.ParameterName = "@action";
            sqlParameter.Value = "select";

            sqlParameter.DbType = DbType.String;
            cmd.Parameters.Add(sqlParameter);
            if (db.Sql.State == ConnectionState.Closed)
                db.Sql.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            List<Department> departmentlist = new List<Department>();  
            while (reader.Read())
            {
                Department objDept = new Department();

                objDept.Id = (int)reader[0];
                objDept.Name = reader[1].ToString();
                departmentlist.Add(objDept);
            }
            db.Sql.Close();
            return departmentlist;   
        }
        public void CreateDepartment(Department department)
        {

            SqlCommand cmd = new SqlCommand("sp_department", db.Sql);
            cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddWithValue("@action", "Create");
            cmd.Parameters.AddWithValue("@Name", department.Name);
           
            if (db.Sql.State == ConnectionState.Closed)
                db.Sql.Open();
            var result = cmd.ExecuteReader();
            db.Sql.Close();

        }
        public void DeleteDepartment(int id)
        {

            SqlCommand cmd = new SqlCommand("sp_department", db.Sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "Delete");
            cmd.Parameters.AddWithValue("@id",id);
            if (db.Sql.State == ConnectionState.Closed)
                db.Sql.Open();
            var result = cmd.ExecuteReader();
            db.Sql.Close();
        }
        public void EditDepartment(Department department)
        {

            SqlCommand cmd = new SqlCommand("sp_department", db.Sql);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "update");
            cmd.Parameters.AddWithValue("@Name", department.Name);

            if (db.Sql.State == ConnectionState.Closed)
                db.Sql.Open();
            var result = cmd.ExecuteReader();
            db.Sql.Close();

        }
    }
}