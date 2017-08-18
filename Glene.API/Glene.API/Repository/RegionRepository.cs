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
    public interface IRegionRepository
    {
        IList<Region> GetAll();
        Region GetByID(int id);
    }
    public class RegionRepository : IRegionRepository
    {
        private DbConnection db = new DbConnection();
        private IList<Region> oList = new List<Region>();
        public Region MapData(SqlDataReader reader)
        {
            Region region = new Region();
            region.RegionID = Convert.ToInt32(reader["RegionID"]);
            region.RegionDescription = reader["RegionDescription"].ToString();
            return region;
        }
            public IList<Region> GetAll()
        {
            List<Region> rList = new List<Region>();
            db.Open();
            string sql = "SELECT *FROM Region";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                Region region = region = MapData(reader);
                rList.Add(region);
            }
            db.Close();
            return rList;
        }

        public Region GetByID(int id)
        {
            Region region = null;
            db.Open();
            string sql = "SELECT *FROM Region WHERE RegionID='" + id + "'";

            db.InitCommand(sql, CommandType.Text);
            //db.AddInputParameter(DbType.String, "@Id", id);
            SqlDataReader reader = db.ExecuteReader();

            if (reader.Read())
            {
                region = MapData(reader);
            }
            db.Close();
            return region;
        }
    }
}