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
    public interface IOrderRepository
    {
        IList<Order> GetAll();
        Order GetByID(int id);
    }
    public class OrderRepository : IOrderRepository
    {
        private DbConnection db = new DbConnection();
        private IList<Order> oList = new List<Order>();
        public Order MapData(SqlDataReader reader)
        {
            Order order = new Order();
            order.OrderID = Convert.ToInt32(reader["OrderID"]);
            order.CustomerID = reader["CustomerID"].ToString();
            order.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
            order.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
            order.RequiredDate = Convert.ToDateTime(reader["RequiredDate"]);
            if (!reader.IsDBNull(reader.GetOrdinal("ShippedDate")))
            {
                order.ShippedDate = Convert.ToDateTime(reader["ShippedDate"]);
            }
            order.ShipVia = Convert.ToInt32(reader["ShipVia"]);
            order.Freight = Convert.ToDecimal(reader["Freight"]);
            order.ShipName = reader["ShipName"].ToString();
            order.ShipAddress= reader["ShipAddress"].ToString();
            order.ShipCity= reader["ShipCity"].ToString();
            order.ShipRegion= reader["ShipRegion"].ToString();
            order.ShipPostalCode= reader["ShipPostalCode"].ToString();
            order.ShipCountry= reader["ShipName"].ToString();
            return order;
        }
            public IList<Order> GetAll()
        {
            List<Order> oList = new List<Order>();
            db.Open();
            string sql = "SELECT *FROM Orders";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                Order order = order = MapData(reader);
                oList.Add(order);
            }
            db.Close();
            return oList;
        }

        public Order GetByID(int id)
        {
            Order order = null;
            db.Open();
            string sql = "SELECT *FROM Orders WHERE OrderID='" + id + "'";

            db.InitCommand(sql, CommandType.Text);
            //db.AddInputParameter(DbType.String, "@Id", id);
            SqlDataReader reader = db.ExecuteReader();

            if (reader.Read())
            {
                order = MapData(reader);
            }
            db.Close();
            return order;
        }
    }
}