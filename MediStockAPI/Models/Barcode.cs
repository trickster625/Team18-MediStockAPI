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
    
    public partial class Barcode
    {
        public int Barcode_ID { get; set; }
        public int Inventory_ID { get; set; }
        public string Barcode_Number { get; set; }
        public Nullable<System.DateTime> Barcode_Date { get; set; }
    
        public virtual Inventory Inventory { get; set; }
    }
}
