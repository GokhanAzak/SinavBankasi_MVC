//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SinavBankasi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestXQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestXQuestion()
        {
            this.QuestionXDuration = new HashSet<QuestionXDuration>();
            this.TestXPaper = new HashSet<TestXPaper>();
        }
    
        public int TestXQuestionId { get; set; }
        public Nullable<int> TestId { get; set; }
        public Nullable<int> QuestionId { get; set; }
        public Nullable<int> QuestionNumber { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Question Question { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionXDuration> QuestionXDuration { get; set; }
        public virtual Test Test { get; set; }
        public virtual Test Test1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestXPaper> TestXPaper { get; set; }
    }
}
