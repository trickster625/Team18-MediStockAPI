using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class JobPositionVM
    {
        public int Position_ID { get; set; }

        public int RoleType_ID { get; set; }

        public string Position_Description { get; set; }

        public string RoleType_Description { get; set; }

        public decimal Position_Compensation { get; set; }
        
        public DateTime Position_Date { get; set; }

    }
}