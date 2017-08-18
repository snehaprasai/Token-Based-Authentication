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
    public interface ICustomerRepository
    { 
        IList<Customer> GetAll();
        Customer GetByID(string id);
    }
    public class CustomerRepository : ICustomerRepository
    {
        private DbConnection db = new DbConnection();
        private IList<Customer> customerList = new List<Customer>();
        private Customer MapData(SqlDataReader reader)
        {
            Customer customer = new Customer();
            customer.CustomerID = reader["CustomerID"].ToString();
            customer.CompanyName = reader["CompanyName"].ToString();
            customer.ContactName = reader["ContactName"].ToString();
            customer.ContactTitle = reader["ContactTitle"].ToString();
            customer.Address = reader["Address"].ToString();
            customer.City = reader["City"].ToString();
            customer.Region = reader["Region"].ToString();
            customer.PostalCode = reader["PostalCode"].ToString();
            customer.Country = reader["Country"].ToString();
            customer.Phone = reader["Phone"].ToString();
            customer.Fax = reader["Fax"].ToString();
            
            return customer;
        }
        public IList<Customer> GetAll()
        {
            List<Customer> Customers = new List<Customer>();
            db.Open();
            string sql = "SELECT *FROM Customers";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                Customer Customer = Customer = MapData(reader);
                Customers.Add(Customer);
            }
            db.Close();
            return Customers;
        }

        public Customer GetByID(string id)
        {
            Customer Customer = null;
            db.Open();
            string sql = "SELECT *FROM Customers WHERE CustomerID='"+id+"'";

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