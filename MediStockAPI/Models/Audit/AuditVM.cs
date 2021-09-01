using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class AuditVM
    {
        public int AuditID { get; set; }
        public DateTime AuditDateTime { get; set; }
        public string TableName { get; set; }
        public string Action { get; set; }
        public string UserID { get; set; }
        public string MachineName { get; set; }
        public string IDName { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
    }
}