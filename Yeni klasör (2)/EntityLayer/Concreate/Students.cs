using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Students
    {
        [Key]
        public int StudentID { get; set; }
        public int WriterID { get; set; }


        [StringLength(50)]
        public string StudentName { get; set; }
        public int HedingID { get; set; }

        [StringLength(50)]
        public string StudentSurName { get; set; }


        [StringLength(100)]
        public string StudentMail { get; set; }

        [StringLength(200)]
        public string StudentPassword { get; set; }

    }
}
