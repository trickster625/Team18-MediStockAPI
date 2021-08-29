using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class Shifts
    {
        public int Shift_ID { get; set; }

        public int Employee_ID { get; set; }

        public int ShiftDate { get; set; }

        public string ShiftStartTime { get; set; }

        public string ShiftEndTime { get; set; }

    }
}