using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using EntityLayer;
using System.Data;

namespace DataLayer
{
    public class DCategory
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection1"].ConnectionString);

        public List<ECategory> ListCategories(string name)
        {
            SqlDataReader ReadRows;
            SqlCommand cmd = new SqlCommand("SP_SEARCH_CATEGORIES", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@PARAM", name);
            ReadRows = cmd.ExecuteReader();
            List<ECategory> CategoryList = new List<ECategory>();

            while (ReadRows.Read())
            {
                CategoryList.Add(new ECategory
                {
                    Id = ReadRows.GetInt32(0),
                    Code = ReadRows.GetString(1),
                    Name = ReadRows.GetString(2),
                    Description = ReadRows.GetString(3),
                });
            }
            connection.Close();
            ReadRows.Close();
            return CategoryList;
        }
        public void InsertCategory(ECategory Category)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERT_CATEGORY", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@NAME", Category.Name);
            cmd.Parameters.AddWithValue("@DESCRIPTION", Category.Description);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateCategory(ECategory Category)
        {
            SqlCommand cmd = new SqlCommand("SP_UPDATE_CATEGORY", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@ID", Category.Id);
            cmd.Parameters.AddWithValue("@NAME", Category.Name);
            cmd.Parameters.AddWithValue("@DESCRIPTION", Category.Description);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteCategory(ECategory Category)
        {
            SqlCommand cmd = new SqlCommand("SP_DELETE_CATEGORY", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            cmd.Parameters.AddWithValue("@ID", Category.Id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
