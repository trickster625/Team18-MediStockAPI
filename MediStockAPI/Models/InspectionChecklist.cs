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
    
    public partial class InspectionChecklist
    {
        public int Checklist_ID { get; set; }
        public int ChecklistItem_ID { get; set; }
        public int Inspection_ID { get; set; }
        public Nullable<bool> Passed { get; set; }
    
        public virtual ItemsChecklist ItemsChecklist { get; set; }
        public virtual VehicleInspection VehicleInspection { get; set; }
    }
}
