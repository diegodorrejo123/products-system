using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EProducts
    {
        private int id;
        private string code;
        private string name;
        private decimal purchase_price;
        private decimal sale_price;
        private int stock;
        private int idbrand;
        private int idcategory;
        private string search;

        private string totalCategories;
        private string totalProducts;
        private string totalBrands;
        private string totalStock;

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public decimal Purchase_price { get => purchase_price; set => purchase_price = value; }
        public decimal Sale_price { get => sale_price; set => sale_price = value; }
        public int Stock { get => stock; set => stock = value; }
        public int Idbrand { get => idbrand; set => idbrand = value; }
        public int Idcategory { get => idcategory; set => idcategory = value; }
        public string Search { get => search; set => search = value; }
        public string TotalCategories { get => totalCategories; set => totalCategories = value; }
        public string TotalProducts { get => totalProducts; set => totalProducts = value; }
        public string TotalBrands { get => totalBrands; set => totalBrands = value; }
        public string TotalStock { get => totalStock; set => totalStock = value; }
    }
}
