using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models.ReceiveOrderVM
{
    public class ReceiveOrderVM
    {
        public int Inventory_QtyReceived { get; set; }
        public string Barcode_Number { get; set; }
        public string Inventory_Name { get; set; }
        public int Inventory_ID { get; set; }
        public int Order_ID { get; set; }
    }
}