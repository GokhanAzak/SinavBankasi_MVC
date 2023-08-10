using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusniesLayer.Abstruct
{
    public interface IExamService
    {
        List<Exam> GetList();
        List<Exam> GetListByWriter(int id);
        void ExamAdd(Exam exam);
       Exam GetByID(int id);
        void ExamDelete(Exam exam);
        void ExamUpdate(Exam exam);

    }
}
