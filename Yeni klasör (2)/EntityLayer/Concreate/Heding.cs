using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
       public class Heding
    {
        [Key] 
        public int HedingID { get; set; }

        [StringLength(50)]
        public string HedingName { get; set;}
        public DateTime HedingDate { get; set; }
        public bool HedingStatus { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }
        public ICollection<Content> Contents { get; set; }

    }
}
