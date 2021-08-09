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
    
    public partial class Call
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Call()
        {
            this.Call_ItemsUsed = new HashSet<Call_ItemsUsed>();
            this.VehicleCalls = new HashSet<VehicleCall>();
        }
    
        public int Call_ID { get; set; }
        public int CallStatus_ID { get; set; }
        public int Reason_ID { get; set; }
        public Nullable<System.DateTime> Call_Date { get; set; }
        public Nullable<System.TimeSpan> Call_StartTime { get; set; }
        public Nullable<System.TimeSpan> Call_EndTime { get; set; }
    
        public virtual CallCancelReason CallCancelReason { get; set; }
        public virtual CallStatu CallStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Call_ItemsUsed> Call_ItemsUsed { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleCall> VehicleCalls { get; set; }
    }
}