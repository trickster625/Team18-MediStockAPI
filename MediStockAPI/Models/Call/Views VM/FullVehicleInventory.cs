using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models.Views_VM
{
    public class FullVehicleInventoryVM
    {
        public int Inventory_ID { get; set; }
        public int Vehicle_ID { get; set; }
        public int MinimumQty { get; set; }
        public int MaximumQty { get; set; }
        public int VehicleInventory_Qty { get; set; }
        public string Inventory_Name { get; set; }
        public int Employee_ID { get; set; }
        public int Call_ID { get; set; }
    }
}