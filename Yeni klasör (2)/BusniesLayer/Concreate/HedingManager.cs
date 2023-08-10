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
    public class HedingManager : IHedingService
    {
        IHedingDal _hedingDal;

        public HedingManager(IHedingDal hedingDal)
        {
            _hedingDal = hedingDal;
        }

        public Heding GetByID(int id)
        {
            return _hedingDal.Get(x => x.HedingID == id);
        }

        public List<Heding> GetList()
        {
            return _hedingDal.List();
        }

        public List<Heding> GetListByWriter(int id)
        {
            return _hedingDal.List(x=>x.WriterID == id);
        }

        public void HedingAdd(Heding heding)
        {
            _hedingDal.insert(heding);
        }

        public void HedingDelete(Heding heding)
        {
           
            _hedingDal.Update(heding);
        }


        public void HedingUpdate(Heding heding)
        {
            _hedingDal.Update(heding);
        }
    }
}
    

