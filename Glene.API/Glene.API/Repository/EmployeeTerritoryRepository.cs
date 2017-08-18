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
    public interface IEmployeeTerritoryRepository
    {
        IList<EmployeeTerritory> GetAll();
        EmployeeTerritory GetByID(int id);
    }
    public class EmployeeTerritoryRepository : IEmployeeTerritoryRepository
    {
        private DbConnection db = new DbConnection();
        private IList<EmployeeTerritory> ETlist = new List<EmployeeTerritory>();
        public EmployeeTerritory MapData(SqlDataReader reader)
        {
            EmployeeTerritory et = new EmployeeTerritory();
            et.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
            et.TerritoryID = reader["TerritoryID"].ToString();
            return et;
        }
            public IList<EmployeeTerritory> GetAll()
        {
            List<EmployeeTerritory> cdList = new List<EmployeeTerritory>();
            db.Open();
            string sql = "SELECT *FROM EmployeeTerritories";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                EmployeeTerritory cd = cd = MapData(reader);
                cdList.Add(cd);
            }
            db.Close();
            return cdList;
        }

        public EmployeeTerritory GetByID(int id)
        {
            EmployeeTerritory cd = null;
            db.Open();
            string sql = "SELECT *FROM EmployeeTerritories WHERE EmployeeID='" + id + "'";

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