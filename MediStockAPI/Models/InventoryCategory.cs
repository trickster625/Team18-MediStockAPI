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
    
    public partial class InventoryCategory
    {
        public int InventoryCategory_ID { get; set; }
        public int InventoryType_ID { get; set; }
        public string InventoryCategory_Description { get; set; }
    
        public virtual InventoryType InventoryType { get; set; }
    }
}
