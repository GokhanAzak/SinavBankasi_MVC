using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniesLayer.Abstruct
{
    public interface IWriterLoginService
    {
        Writer GetWriter(string username, string password);

    }
}
