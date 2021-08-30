using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class FullStockTakeVM
    {
        public int StockTake_ID { get; set; }
        public int Employee_ID { get; set; }
        public Nullable<System.DateTime> StockTake_DateTime { get; set; }
        public int Inventory_ID { get; set; }
        public Nullable<int> StockTakeTotal_Qty { get; set; }
    }
}