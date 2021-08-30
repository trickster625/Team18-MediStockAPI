using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models.ReportingVM
{
    public class JobApplicationReportVM
    {
        public int Position_ID { get; set; }
        public string Position_Description { get; set; }
        public bool shortListed { get; set; }
    }
}