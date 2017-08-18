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
    public interface IContactRepository
    {
        IList<Contact> GetAll();
        Contact GetByID(int id);
    }
    public class ContactRepository : IContactRepository
    {
        private DbConnection db = new DbConnection();
        private IList<Contact> ContactList = new List<Contact>();
        public Contact MapData(SqlDataReader reader)
        {
            Contact contact = new Contact();
            contact.ContactID = Convert.ToInt32(reader["ContactID"]);
            contact.CompanyName = reader["CompanyName"].ToString();
            contact.ContactName = reader["ContactName"].ToString();
            contact.ContactType = reader["ContactType"].ToString();
            contact.Address = reader["Address"].ToString();
            contact.City = reader["City"].ToString();
            contact.Region = reader["Region"].ToString();
            contact.PostalCode = reader["PostalCode"].ToString();
            contact.Country = reader["Country"].ToString();
            contact.Phone = reader["Phone"].ToString();
            contact.Extension = reader["Extension"].ToString();
            contact.Fax = reader["Fax"].ToString();
            contact.HomePage = reader["HomePage"].ToString();
            contact.PhotoPath = reader["PhotoPath"].ToString();
            contact.Photo =  reader["Photo"].ToString();

            return contact;
        }
            public IList<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();
            db.Open();
            string sql = "SELECT *FROM Contacts";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                Contact contact = contact = MapData(reader);
                contacts.Add(contact);
            }
            db.Close();
            return contacts; 
        }

        public Contact GetByID(int id)
        {
            Contact Contact = null;
            db.Open();
            string sql = "SELECT *FROM Contacts WHERE ContactID='" + id + "'";

            db.InitCommand(sql, CommandType.Text);
            //db.AddInputParameter(DbType.String, "@Id", id);
            SqlDataReader reader = db.ExecuteReader();

            if (reader.Read())
            {
                Contact = MapData(reader);
            }
            db.Close();
            return Contact;
        }
    }
}