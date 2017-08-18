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
    public interface IShipperRepository
    {
        IList<Shipper> GetAll();
        Shipper GetByID(int id);
    }
    public class ShipperRepository : IShipperRepository
    {
        private DbConnection db = new DbConnection();
        private IList<Shipper> sList = new List<Shipper>();
        public Shipper MapData(SqlDataReader reader)
        {
            Shipper shipper = new Shipper();
            shipper.ShipperID = Convert.ToInt32(reader["ShipperID"]);
            shipper.CompanyName = reader["CompanyName"].ToString();
            shipper.Phone = reader["Phone"].ToString();
            return shipper;
        }
        public IList<Shipper> GetAll()
        {
            List<Shipper> sList = new List<Shipper>();
            db.Open();
            string sql = "SELECT *FROM Shippers";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                Shipper shipper = shipper = MapData(reader);
                sList.Add(shipper);
            }
            db.Close();
            return sList;
        }

        public Shipper GetByID(int id)
        {
            Shipper shipper = null;
            db.Open();
            string sql = "SELECT *FROM Shippers WHERE ShipperID='" + id + "'";

            db.InitCommand(sql, CommandType.Text);
            //db.AddInputParameter(DbType.String, "@Id", id);
            SqlDataReader reader = db.ExecuteReader();

            if (reader.Read())
            {
                shipper = MapData(reader);
            }
            db.Close();
            return shipper;
        }
    }
}