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
    
    public partial class Write_OffReason
    {
        public Write_OffReason()
        {
            this.Written_OffInventory = new HashSet<Written_OffInventory>();
        }
    
        public int Write_OffReason_ID { get; set; }
        public string Write_OffReason_Description { get; set; }
    
        public virtual ICollection<Written_OffInventory> Written_OffInventory { get; set; }
    }
}
