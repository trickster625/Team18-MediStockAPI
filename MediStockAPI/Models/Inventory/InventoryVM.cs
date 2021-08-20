using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class InventoryVM
    {
        public int Inventory_ID { get; set; }
        public int InventoryType_ID { get; set; }
        public string Inventory_Name { get; set; }
        public Nullable<decimal> Inventory_LatestPrice { get; set; }
        public Nullable<int> Inventory_BaseCampQty { get; set; }
        public Nullable<int> Inventory_DaysToExpire { get; set; }
        public byte[] Inventory_Picture { get; set; }
    }
}