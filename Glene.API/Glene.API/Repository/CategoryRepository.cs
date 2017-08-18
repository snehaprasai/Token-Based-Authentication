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
    public interface ICategoryRepository
    {
        IList<Category> GetAll();
        Category GetByID(int id);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private DbConnection db = new DbConnection();
        private IList<Category> CategoryList = new List<Category>();
        public Category MapData(SqlDataReader reader)
        {
            Category category = new Category();
            category.CategoryID = Convert.ToInt32(reader["CategoryID"]);
            category.CategoryName = reader["CategoryName"].ToString();
            category.Description = reader["CategoryName"].ToString();
            category.Picture = reader["Picture"].ToString();

            return category;
        }

        public IList<Category> GetAll()
        {
            List<Category> CategoryList = new List<Category>();
            db.Open();
            string sql = "SELECT *FROM Categories";
            db.InitCommand(sql, CommandType.Text);
            SqlDataReader reader = db.ExecuteReader();

            while (reader.Read())
            {
                Category category = category = MapData(reader);
                CategoryList.Add(category);
            }
            db.Close();
            return CategoryList;
        }

        public Category GetByID(int id)
        {
            Category Category = null;
            db.Open();
            string sql = "SELECT *FROM Categories WHERE CategoryID='" + id + "'";

            db.InitCommand(sql, CommandType.Text);
            //db.AddInputParameter(DbType.String, "@Id", id);
            SqlDataReader reader = db.ExecuteReader();

            if (reader.Read())
            {
                Category = MapData(reader);
            }
            db.Close();
            return Category;
        }
    }
}