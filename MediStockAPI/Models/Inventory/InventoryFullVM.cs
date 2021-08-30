using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class InventoryFullVM
    {
        public int Inventory_ID { get; set; }
        public int InventoryCategory_ID { get; set; }
        public string InventoryCategory_Description { get; set; }
        public string Inventory_Name { get; set; }
        public decimal Inventory_LatestPrice { get; set; }
        public int Inventory_BaseCampQty { get; set; }
        public byte[] Inventory_Picture { get; set; }
        public int[] Barcode_ID { get; set; }
        public string[] BarcodeNumber { get; set; }
    }
}