using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Exam
    {
        [Key]
        public int ExamID { get; set; }
        
        public DateTime ExamDate { get; set; }

        public string ExamValue {get; set; }

        public int WriterID { get; set; }

        [StringLength(50)]
        public string WriterName { get; set; }

        [StringLength(50)]
        public string WriterSurName { get; set; }
        [StringLength(50)]
        public string WriterMail { get; set; }

        public int CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        public int Duration { get; set; }

        [StringLength(100)]
        public string Description { get; set; }


        public ICollection<Writer> Writers { get; set; }




    }
}
