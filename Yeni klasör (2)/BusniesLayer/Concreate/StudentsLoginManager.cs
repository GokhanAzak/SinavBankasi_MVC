using BusniesLayer.Abstruct;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniesLayer.Concreate
{
    public class StudentsLoginManager:IStudentsLoginSevice
    {
        IStudentsDal _studentDal;

        public StudentsLoginManager(IStudentsDal studentDal)
        {
            _studentDal = studentDal;
        }

        public Students GetByID(int id)
        {
            return _studentDal.Get(x => x.StudentID == id);
        }

        public List<Students> GetListByWriter(int id)
        {
            return _studentDal.List(x => x.StudentID == id);
        }

        public Students GetStudent(string username, string password)
        {
            return _studentDal.Get(x => x.StudentMail == username && x.StudentPassword == password);

        }

        public void StudentsUpdate(Students students)
        {
            _studentDal.Update(students);
        }

    }
}
