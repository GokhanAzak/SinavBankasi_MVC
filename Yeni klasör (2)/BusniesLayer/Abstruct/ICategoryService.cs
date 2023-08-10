using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniesLayer.Abstruct
{
    public interface ICategoryService
    {
        List<Category> GetList();
        List<Content> GetListByHedingID(int id);
        void CategoryAdd(Category category);
        Category GetByID(int id);
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
       
    }
}
