using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models
{
    public class EmployeeVM
    {
        public int Employee_ID { get; set; }
        public int EmployeeTitle_ID { get; set; }
        public int SecurityQuestion_ID { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Surname { get; set; }
        public int Employee_IDNumber { get; set; }
        public int Employee_ContactNumber { get; set; }
        public string Employee_EmailAddress { get; set; }
        public string Employee_HashedPassword { get; set; }
        public string Employee_SecurityQuestionAnswer { get; set; }
        public int Employee_SARSTaxNumber { get; set; }
        public int Employee_Signature { get; set; }
    }
}