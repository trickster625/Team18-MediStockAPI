//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MediStockAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class JobPosition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobPosition()
        {
            this.JobApplications = new HashSet<JobApplication>();
        }
    
        public int Position_ID { get; set; }
        public int RoleType_ID { get; set; }
        public string Position_Description { get; set; }
        public Nullable<decimal> Position_Compensation { get; set; }
        public Nullable<System.DateTime> Position_Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobApplication> JobApplications { get; set; }
        public virtual RoleType RoleType { get; set; }
    }
}
