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
    public interface IOrderDetailRepository
    {
        IList<OrderDetail> GetAll();
        OrderDetail GetByID(int id);
    }
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private DbConnection db = new DbConnection();
        private IList<OrderDetail> oList = new List<OrderDetail>();
        public OrderDetail MapData(SqlDataReader reader)
        {
            OrderDetail od = new OrderDetail();
            od.OrderID = Convert.ToInt32(reader["OrderID"]);
            od.ProductID = Convert.ToInt32(reader["ProductID"]);
            od.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
            od.Quantity = Convert.ToInt16(reader["Quantity"]);
            od.Discount = Convert.ToDecimal(reader["Discount"]);
            return od;
        }
            public IList<OrderDetail> GetAll()
        {
            List<OrderDetail> oList = new List<OrderDetail>();
            db.Open();
            string sql = "SELECT *FROM OrderDetails";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                OrderDetail order = order = MapData(reader);
                oList.Add(order);
            }
            db.Close();
            return oList;
        }

        public OrderDetail GetByID(int id)
        {
            OrderDetail od = null;
            db.Open();
            string sql = "SELECT *FROM OrderDetails WHERE OrderID='" + id + "'";

            db.InitCommand(sql, CommandType.Text);
            //db.AddInputParameter(DbType.String, "@Id", id);
            SqlDataReader reader = db.ExecuteReader();

            if (reader.Read())
            {
                od = MapData(reader);
            }
            db.Close();
            return od;
        }
    }
}