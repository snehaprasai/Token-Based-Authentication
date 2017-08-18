using Glene.API.DbUtil;
using Glene.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Glene.API.Repository
{
    public interface IEmployeeRepository
    {
        IList<Employee> GetAll();
        Employee GetByID(int id);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private DbConnection db = new DbConnection();
        private IList<Employee> Employeelist = new List<Employee>();
        public Employee MapData(SqlDataReader reader)
        {
            Employee em = new Employee();
            em.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
            em.LastName = reader["LastName"].ToString();
            em.FirstName = reader["FirstName"].ToString();
            em.Title= reader["Title"].ToString();
            em.TitleOfCourtesy= reader["TitleOfCourtesy"].ToString();
            em.BirthDate = Convert.ToDateTime(reader["BirthDate"]);
            em.HireDate= Convert.ToDateTime(reader["HireDate"]);
            em.Address = reader["Address"].ToString();
            em.City = reader["City"].ToString();
            em.Region = reader["Region"].ToString();
            em.PostalCode = reader["PostalCode"].ToString();
            em.Country = reader["Country"].ToString();
            em.HomePhone = reader["HomePhone"].ToString();
            em.Extension = reader["Extension"].ToString();
            em.Photo = reader["Photo"].ToString();
            em.Notes= reader["Notes"].ToString();
            
            if (!reader.IsDBNull(reader.GetOrdinal("ReportsTo")))
            {
                em.ReportsTo = Convert.ToInt32(reader["ReportsTo"]);
            }
            em.PhotoPath= reader["PhotoPath"].ToString();
            return em;
        }
        public IList<Employee> GetAll()
        {
            List<Employee> cdList = new List<Employee>();
            db.Open();
            string sql = "SELECT *FROM Employees";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                Employee cd = cd = MapData(reader);
                cdList.Add(cd);
            }
            db.Close();
            return cdList;
        }

        public Employee GetByID(int id)
        {
            Employee cd = null;
            db.Open();
            string sql = "SELECT *FROM Employees WHERE EmployeeID='" + id + "'";

            db.InitCommand(sql, CommandType.Text);
            //db.AddInputParameter(DbType.String, "@Id", id);
            SqlDataReader reader = db.ExecuteReader();

            if (reader.Read())
            {
                cd = MapData(reader);
            }
            db.Close();
            return cd;
        }
    }
}