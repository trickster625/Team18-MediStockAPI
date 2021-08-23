﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models.Views_VM
{
    public class FullCallVM
    {
        public int Call_ID { get; set; }
        public int CallStatus_ID { get; set; }
        public int Reason_ID { get; set; }
        public DateTime Call_Date { get; set; }
        public TimeSpan Call_StartTime { get; set; }
        public TimeSpan Call_EndTime { get; set; }
        public int DOA_Number { get; set; }
        public int PRF_Number { get; set; }
        public string Reason_Description { get; set; }
        public string CallStatus_Description {get;set;}
        public int Employee_ID { get; set; }
        public string Employee_Surname { get; set; }
    }
}