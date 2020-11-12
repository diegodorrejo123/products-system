using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BProducts
    {
        DProducts prod = new DProducts();
        EProducts eprod = new EProducts();

        public DataTable ListProducts()
        {
            return prod.ListProducts();
        }
        public DataTable SearchProducts(string search)
        {
            eprod.Search = search;
            return prod.SearchProduct(eprod);
        }
        public void InsertProduct(EProducts produ)
        {
            prod.InsertProduct(produ);
        }
        public void DeleteProduct(int id)
        {
            prod.DeleteProduct(id);
        }
        public void UpdateProduct(EProducts produ)
        {
            prod.UpdateProduct(produ);
        }
        public void ShowTotals(EProducts produ)
        {
            prod.ShowTotals(produ);
        }
    }
}
