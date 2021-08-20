using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class InventoryVM
    {
        public int InventoryID { get; set; }
        public string InventoryName { get; set; }
        public int InventoryTypeID { get; set; }
        public string InventoryType { get; set; }
    }
}