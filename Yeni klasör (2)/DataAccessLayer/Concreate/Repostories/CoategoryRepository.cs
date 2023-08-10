using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate.Repostories
{
    public class CoategoryRepository : ICategoryDal
    {
        Context c =new Context();
        public DbSet<Category> _object;
        public void Delete(Category p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public override bool Equals(object obj)
        {
            return obj is CoategoryRepository repository &&
                   EqualityComparer<DbSet<Category>>.Default.Equals(_object, repository._object);
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return 368901877 + EqualityComparer<DbSet<Category>>.Default.GetHashCode(_object);
        }

      

        public void insert(Category p)
        {
            _object.Add(p);
            c.SaveChanges();
            
        }

        public List<Category> List()
        {
           return _object.ToList();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category p)
        {
            c.SaveChanges();
        }
    }
}

