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
    public class ContactManager:IContactService
    {
         IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact Contact)
        {
            _contactDal.insert(Contact);
        }

        public void ContactDelete(Contact Contact)
        {
            _contactDal.Delete(Contact);
        }

        public void ContactUpdate(Contact Contact)
        {
          _contactDal.Update(Contact);
        }

        public Contact GetByID(int id)
        {
          return _contactDal.Get(x=>x.ContectID==id);
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }
    }
}
