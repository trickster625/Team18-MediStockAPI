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
    
    public partial class AuditLog
    {
        public long AuditID { get; set; }
        public Nullable<System.DateTime> AuditDateTime { get; set; }
        public string TableName { get; set; }
        public string Action { get; set; }
        public string UserID { get; set; }
        public string MachineName { get; set; }
        public string IDName { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
    }
}
