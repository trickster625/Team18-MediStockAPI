using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models.ReportingVM
{
    public class InspectionReportVM
    {
        public int Checklist_ID { get; set; }
        public string Checklist_Name { get; set; }
        public int ChecklistItem_ID { get; set; }
        public string ChecklistItem_Description { get; set; }
        public bool Passed { get; set; }
    }
}