using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class BBrand
    {
        DBrand dbrand = new DBrand();
        public List<EBrand> ListBrands(string search)
        {
            return dbrand.ListBrands(search);
        }

        public void InsertBrand(EBrand brand)
        {
            dbrand.InsertBrand(brand);
        }

        public void UpdateBrand(EBrand brand)
        {
            dbrand.UpdateBrand(brand);
        }
        public void DeleteBrand(EBrand brand)
        {
            dbrand.DeleteBrand(brand);
        }
    }
}
