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
    public interface ICustomerDemoRepository
    {
        IList<CustomerDemographics> GetAll();
        CustomerDemographics GetByID(string id);
    }
    public class CustomerDemoRepository : ICustomerDemoRepository
    {
        private DbConnection db = new DbConnection();
        private IList<CustomerDemographics> CustomerDemographicslist = new List<CustomerDemographics>();
        public CustomerDemographics MapData(SqlDataReader reader)
        {
            CustomerDemographics cd = new CustomerDemographics();
            cd.CustomerTypeID = reader["CustomerTypeID"].ToString();
            cd.CustomerDesc = reader["CustomerDesc"].ToString();
            return cd;
        }
        public IList<CustomerDemographics> GetAll()
        {
            List<CustomerDemographics> cdList = new List<CustomerDemographics>();
            db.Open();
            string sql = "SELECT *FROM CustomerDemographics";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                CustomerDemographics cd = cd = MapData(reader);
                cdList.Add(cd);
            }
            db.Close();
            return cdList;
        }

        public CustomerDemographics GetByID(string id)
        {
            CustomerDemographics cd = null;
            db.Open();
            string sql = "SELECT *FROM CustomerDemographics WHERE CustomerTypeID='" + id + "'";

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