using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models.ReportingVM
{
    public class callLogOutputVM
    {
        public int Call_ID { get; set; }
        public int CallStatus_ID { get; set; }
        public string CallStatus_Description { get; set; }
    }
}