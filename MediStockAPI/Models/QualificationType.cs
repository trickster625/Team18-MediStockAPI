//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MediStockAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class QualificationType
    {
        public QualificationType()
        {
            this.Employees = new HashSet<Employee>();
        }
    
        public int QualificationType_ID { get; set; }
        public string QualificationType_Description { get; set; }
    
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
