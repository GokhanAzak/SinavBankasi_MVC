using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //CRUD
    //Type name(); ile olur.
    public interface IRepository<T>
    {
        List<T> List();
        void insert(T p);
        T Get(Expression<Func<T, bool>> filter);
        void Update(T p);
        void Delete(T p);

        List<T> List(Expression<Func<T, bool>> filter);


    }
}
