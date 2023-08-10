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
    public class ExamManager : IExamService
    {
        IExamDal _examDal;

        public ExamManager(IExamDal examDal)
        {
            _examDal = examDal;
        }

        public void ExamAdd(Exam exam)
        {
            _examDal.insert(exam);
        }

        public void ExamDelete(Exam exam)
        {
            throw new NotImplementedException();
        }

        public void ExamUpdate(Exam exam)
        {
            throw new NotImplementedException();
        }

        public Exam GetByID(int id)
        {
            return _examDal.Get(x => x.ExamID == id);
        }

        public List<Exam> GetList()
        {
           return _examDal.List(); 
        }



        public List<Exam> GetListByWriter(int id)
        {
            return _examDal.List(x => x.WriterID == id);
        }

        
    }
}
