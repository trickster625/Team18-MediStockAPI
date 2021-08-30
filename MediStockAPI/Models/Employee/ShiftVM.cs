using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class ShiftVM
    {
        public int Shift_ID { get; set; }

        public int Employee_ID { get; set; }

        public DateTime ShiftDate { get; set; }

        public TimeSpan ShiftStartTime { get; set; }

        public TimeSpan shiftEndTime { get; set; }
    }
}