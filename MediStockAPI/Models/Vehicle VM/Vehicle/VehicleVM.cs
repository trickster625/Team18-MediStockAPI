using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class VehicleVM
    {
        public int Vehicle_ID { get; set; }

        public int VehicleType_ID { get; set; }

        public string Vehicle_Name { get; set; }

        public string VehicleType_Description { get; set; }
    }
}