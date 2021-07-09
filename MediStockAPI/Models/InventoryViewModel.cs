using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class InventoryViewModel
    {
        public int InventoryId { get; set; }
        public string InventoryName { get; set; }
        public decimal InventoryPrice { get; set; }
    }
}