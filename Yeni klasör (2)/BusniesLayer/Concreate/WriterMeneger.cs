using BusniesLayer.Abstruct;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniesLayer.Concreate
{
    public class WriterMeneger : IWriterService
    {
        IWiterDal _writerDal;

        public WriterMeneger(IWiterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetByID(int id)
        {
           return _writerDal.Get(x=>x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void Writeradd(Writer writer)
        {
            _writerDal.insert(writer);
        }

        public void WriterAdd(Writer writer)
        {
            throw new NotImplementedException();
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void Writerupdate(Writer writer)
        {
            _writerDal.Update(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            throw new NotImplementedException();
        }
    }
}
