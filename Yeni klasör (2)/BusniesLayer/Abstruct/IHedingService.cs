using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BusniesLayer.Abstruct
{
    public interface IHedingService
    {
        List<Heding> GetList();
        List<Heding> GetListByWriter(int id);
        void HedingAdd(Heding heding);
        Heding GetByID(int id);
        void HedingDelete(Heding heding);
        void HedingUpdate(Heding heding);

    }
}
