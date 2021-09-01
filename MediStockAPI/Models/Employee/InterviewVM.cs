using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class InterviewVM
    {
        public int Interview_ID { get; set; }

        public int Candidate_ID { get; set; }

        public int InterviewType_ID { get; set; }

        public int Employee_ID { get; set; }

        public Nullable<System.DateTime> ScheduledDate_Time { get; set; }

        public string InterviewMethod { get; set; }

        public string Address { get; set; }

    }
}