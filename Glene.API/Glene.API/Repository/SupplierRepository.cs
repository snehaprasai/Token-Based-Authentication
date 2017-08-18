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
    public interface ISupplierRepository
    {
        IList<Supplier> GetAll();
        Supplier GetByID(int id);
    }
    public class SupplierRepository : ISupplierRepository
    {
        private DbConnection db = new DbConnection();
        private IList<Supplier> sList = new List<Supplier>();
        public Supplier MapData(SqlDataReader reader)
        {
            Supplier supplier = new Supplier();
            supplier.SupplierID = Convert.ToInt32(reader["SupplierID"]);
            supplier.CompanyName = reader["CompanyName"].ToString();
            supplier.ContactName = reader["ContactName"].ToString(); ;
            supplier.ContactTitle = reader["ContactTitle"].ToString(); ;
            supplier.Address = reader["Address"].ToString(); 
            supplier.City = reader["City"].ToString();
            supplier.Region = reader["Region"].ToString();
            supplier.PostalCode = reader["PostalCode"].ToString();
            supplier.Country = reader["Country"].ToString();
            supplier.Phone = reader["Phone"].ToString();
            supplier.Fax = reader["Fax"].ToString();
            supplier.HomePage = reader["HomePage"].ToString();
            return supplier;
        }
        public IList<Supplier> GetAll()
        {
            List<Supplier> Suppliers = new List<Supplier>();
            db.Open();
            string sql = "SELECT *FROM Suppliers";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                Supplier Supplier = Supplier = MapData(reader);
                Suppliers.Add(Supplier);
            }
            db.Close();
            return Suppliers;
        }

        public Supplier GetByID(int id)
        {
            Supplier Suppliers = null;
            db.Open();
            string sql = "SELECT *FROM Suppliers WHERE SupplierID='" + id + "'";

            db.InitCommand(sql, CommandType.Text);
            //db.AddInputParameter(DbType.String, "@Id", id);
            SqlDataReader reader = db.ExecuteReader();

            if (reader.Read())
            {
                Suppliers = MapData(reader);
            }
            db.Close();
            return Suppliers;
        }
    }
}