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
    public class WriterLoginManager:IWriterLoginService
    {
        IWiterDal _writerDal;

        public WriterLoginManager(IWiterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetWriter(string username, string password)
        {
           return _writerDal.Get(x=>x.WriterMail==username&&x.WriterPassword==password);
        }
    }
}
