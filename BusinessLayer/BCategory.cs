using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using EntityLayer;
namespace BusinessLayer
{
    public class BCategory
    {
        DCategory DataCategory = new DCategory();

        public List<ECategory> ListCategories(string search)
        {
            return DataCategory.ListCategories(search);
        }
        public void InsertCategory(ECategory Category)
        {
            DataCategory.InsertCategory(Category);
        }
        public void UpdateCategory(ECategory Category)
        {
            DataCategory.UpdateCategory(Category);
        }
        public void DeleteCategory(ECategory Category)
        {
            DataCategory.DeleteCategory(Category);
        }
    }
}
