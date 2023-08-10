using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityLayer.Concreate
{
    public class Content

    {
        [Key]
        public int ContentID { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }

        public DateTime ContentDate { get; set; }

        public bool ContentStatus { get; set; }

       
        public int HedingID { get; set; }
        public virtual Heding Heding { get; set; }
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }

      


    }
}
