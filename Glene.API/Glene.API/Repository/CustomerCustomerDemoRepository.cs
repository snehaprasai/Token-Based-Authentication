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
    public interface ICustomerCustomerDemoRepository
    {
        IList<CustomerCustomerDemo> GetAll();
        CustomerCustomerDemo GetByID(string id);
    }
    public class CustomerCustomerDemoRepository : ICustomerCustomerDemoRepository
    {
        private DbConnection db = new DbConnection();
        private IList<CustomerCustomerDemo> customerList = new List<CustomerCustomerDemo>();
        private CustomerCustomerDemo MapData(SqlDataReader reader)
        {
            CustomerCustomerDemo ccd = new CustomerCustomerDemo();
            ccd.CustomerID = reader["CustomerID"].ToString();
            ccd.CustomerTypeID = reader["CustomerTypeID"].ToString();
            return ccd;
        }
            public IList<CustomerCustomerDemo> GetAll()
        {
            List<CustomerCustomerDemo> Customers = new List<CustomerCustomerDemo>();
            db.Open();
            string sql = "SELECT *FROM CustomerCustomerDemo";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                CustomerCustomerDemo customerCustomerDemo = customerCustomerDemo = MapData(reader);
                Customers.Add(customerCustomerDemo);
            }
            db.Close();
            return Customers;
        }

        public CustomerCustomerDemo GetByID(string id)
        {
            CustomerCustomerDemo Customer = null;
            db.Open();
            string sql = "SELECT *FROM CustomerCustomerDemo WHERE CustomerID='" + id + "'";

            db.InitCommand(sql, CommandType.Text);
            //db.AddInputParameter(DbType.String, "@Id", id);
            SqlDataReader reader = db.ExecuteReader();

            if (reader.Read())
            {
                Customer = MapData(reader);
            }
            db.Close();
            return Customer;
        }
    }
}