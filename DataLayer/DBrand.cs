using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataLayer
{
    public class DBrand
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection1"].ConnectionString);

        public void InsertBrand(EBrand brand)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERT_BRAND", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@NAME", brand.Name);
            cmd.Parameters.AddWithValue("@DESCRIPTION", brand.Description);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<EBrand> ListBrands(string search)
        {
            SqlCommand cmd = new SqlCommand("SP_SEARCH_BRAND", con);
            SqlDataReader ReadRows;
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@SEARCH", search);
            ReadRows = cmd.ExecuteReader();
            
            List<EBrand> brands = new List<EBrand>();
            while (ReadRows.Read())
            {
                brands.Add(new EBrand
                {
                    Id = ReadRows.GetInt32(0),
                    Code = ReadRows.GetString(1),
                    Name = ReadRows.GetString(2),
                    Description = ReadRows.GetString(3)
                });
            }
            ReadRows.Close();
            con.Close();
            return brands;
        }

        public void UpdateBrand(EBrand brand)
        {
            SqlCommand cmd = new SqlCommand("SP_UPDATE_BRAND", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@ID", brand.Id);
            cmd.Parameters.AddWithValue("@NAME", brand.Name);
            cmd.Parameters.AddWithValue("@DESCRIPTION", brand.Description);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteBrand(EBrand brand)
        {
            SqlCommand cmd = new SqlCommand("SP_DELETE_BRAND", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@ID", brand.Id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
