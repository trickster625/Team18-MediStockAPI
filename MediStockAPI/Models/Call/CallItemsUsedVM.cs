using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class CallItemsUsedVM
    {
        public int ItemsUsed_ID { get; set; }
        public int Call_ID { get; set; }
        public int Inventory_ID { get; set; }
        public int ItemsUsed_Qty { get; set; }
    }
}