using BusniesLayer.Abstruct;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate.Repostories;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniesLayer.Concreate
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {
            _categoryDal.insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
           return _categoryDal.Get(x=>x.CategoryID==id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public List<Content> GetListByHedingID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetListByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
