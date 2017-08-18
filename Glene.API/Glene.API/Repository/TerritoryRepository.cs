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
    public interface ITerritoryRepository
    {
        IList<Territory> GetAll();
        Territory GetByID(string id);
    }
    public class TerritoryRepository : ITerritoryRepository
    {
        private DbConnection db = new DbConnection();
        private IList<Territory> TerritoryList = new List<Territory>();
        private Territory MapData(SqlDataReader reader)
        {
            Territory territory = new Territory();
            territory.TerritoryID = reader["TerritoryID"].ToString();
            territory.TerritoryDescription = reader["TerritoryDescription"].ToString();
            territory.RegionID = Convert.ToInt32(reader["RegionID"]);
            return territory;
        }
        public IList<Territory> GetAll()
        {
            List<Territory> t = new List<Territory>();
            db.Open();
            string sql = "SELECT *FROM Territories";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                Territory territory = territory = MapData(reader);
                t.Add(territory);
            }
            db.Close();
            return t;
        }

        public Territory GetByID(string id)
        {
            Territory territory = null;
            db.Open();
            string sql = "SELECT *FROM Territories WHERE TerritoryID='" + id + "'";

            db.InitCommand(sql, CommandType.Text);
            //db.AddInputParameter(DbType.String, "@Id", id);
            SqlDataReader reader = db.ExecuteReader();

            if (reader.Read())
            {
                territory = MapData(reader);
            }
            db.Close();
            return territory;
        }
    }
}