using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniesLayer.Abstruct
{
    public interface IStudentsLoginSevice
    {
        Students GetStudent(string username, string password);
        Students GetByID(int id);
        void StudentsUpdate(Students students);
        List<Students> GetListByWriter(int id);
    }
}
