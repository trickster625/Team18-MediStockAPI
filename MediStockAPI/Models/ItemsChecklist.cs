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
    
    public partial class ItemsChecklist
    {
        public ItemsChecklist()
        {
            this.InspectionChecklists = new HashSet<InspectionChecklist>();
        }
    
        public int Checklist_ID { get; set; }
        public int ChecklistItem_ID { get; set; }
    
        public virtual Checklist Checklist { get; set; }
        public virtual ChecklistItem ChecklistItem { get; set; }
        public virtual ICollection<InspectionChecklist> InspectionChecklists { get; set; }
    }
}
