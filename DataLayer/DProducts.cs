using EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DProducts
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection1"].ConnectionString);
        public DataTable ListProducts()
        {
            DataTable table = new DataTable();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("SP_LISTPRODUCTS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            dr = cmd.ExecuteReader();
            table.Load(dr);
            dr.Close();
            con.Close();
            return table;
        }

        public DataTable SearchProduct(EProducts prod)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_SEARCH_PRODUCTS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@NAME", prod.Search);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void InsertProduct(EProducts prod)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERT_PRODUCT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@NAME", prod.Name);
            cmd.Parameters.AddWithValue("@PURCHASE_PRICE", prod.Purchase_price);
            cmd.Parameters.AddWithValue("@SALE_PRICE", prod.Sale_price);
            cmd.Parameters.AddWithValue("@STOCK", prod.Stock);
            cmd.Parameters.AddWithValue("@IDCATEGORY", prod.Idcategory);
            cmd.Parameters.AddWithValue("@IDBRAND", prod.Idbrand);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateProduct(EProducts prod)
        {
            SqlCommand cmd = new SqlCommand("SP_UPDATE_PRODUCT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@ID", prod.Id);
            cmd.Parameters.AddWithValue("@NAME", prod.Name);
            cmd.Parameters.AddWithValue("@PURCHASE_PRICE", prod.Purchase_price);
            cmd.Parameters.AddWithValue("@SALE_PRICE", prod.Sale_price);
            cmd.Parameters.AddWithValue("@STOCK", prod.Stock);
            cmd.Parameters.AddWithValue("@IDCATEGORY", prod.Idcategory);
            cmd.Parameters.AddWithValue("@IDBRAND", prod.Idbrand);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteProduct(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_DELETE_PRODUCT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void ShowTotals(EProducts prod)
        {
            SqlCommand cmd = new SqlCommand("SP_COUNTALL", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter totalCategories = new SqlParameter("@totalCategories", 0);
            totalCategories.Direction = ParameterDirection.Output;

            SqlParameter totalProducts = new SqlParameter("@totalProducts", 0);
            totalProducts.Direction = ParameterDirection.Output;

            SqlParameter totalBrands = new SqlParameter("@totalBrands", 0);
            totalBrands.Direction = ParameterDirection.Output;

            SqlParameter totalStock = new SqlParameter("@totalStock", 0);
            totalStock.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(totalCategories);
            cmd.Parameters.Add(totalProducts);
            cmd.Parameters.Add(totalBrands);
            cmd.Parameters.Add(totalStock);

            con.Open();

            cmd.ExecuteNonQuery();

            prod.TotalCategories = cmd.Parameters["@totalCategories"].Value.ToString();
            prod.TotalProducts = cmd.Parameters["@totalProducts"].Value.ToString();
            prod.TotalBrands = cmd.Parameters["@totalBrands"].Value.ToString();
            prod.TotalStock = cmd.Parameters["@totalStock"].Value.ToString();

            con.Close();
        }
    }
}
