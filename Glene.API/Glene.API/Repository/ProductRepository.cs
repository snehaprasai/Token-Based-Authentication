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
    public interface IProductRepository
    {
        IList<Product> GetAll();
        Product GetByID(int id);
    }
    public class ProductRepository : IProductRepository
    {
        private DbConnection db = new DbConnection();
        private IList<Product> oList = new List<Product>();
        public Product MapData(SqlDataReader reader)
        {
            Product product = new Product();
            product.ProductID = Convert.ToInt32(reader["ProductID"]);
            product.ProductName = reader["ProductName"].ToString();
            product.SupplierID= Convert.ToInt32(reader["SupplierID"]);
            product.CategoryID= Convert.ToInt32(reader["CategoryID"]);
            product.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
            product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
            product.UnitsInStock= Convert.ToInt16(reader["UnitsInStock"]);
            product.UnitsOnOrder= Convert.ToInt16(reader["UnitsOnOrder"]);
            product.ReorderLevel = Convert.ToInt16(reader["ReorderLevel"]);
            product.Discontinued = Convert.ToBoolean(reader["Discontinued"]);
            return product;
        }
            public IList<Product> GetAll()
        {
            List<Product> pList = new List<Product>();
            db.Open();
            string sql = "SELECT *FROM Products";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                Product product = product = MapData(reader);
                pList.Add(product);
            }
            db.Close();
            return pList;
        }

        public Product GetByID(int id)
        {
            Product product = null;
            db.Open();
            string sql = "SELECT *FROM Products WHERE ProductID='" + id + "'";

            db.InitCommand(sql, CommandType.Text);
            //db.AddInputParameter(DbType.String, "@Id", id);
            SqlDataReader reader = db.ExecuteReader();

            if (reader.Read())
            {
                product = MapData(reader);
            }
            db.Close();
            return product;
        }
    }
}