﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models.Employee
{
    public class Employee
    {
        public int Employee_ID { get; set; }

        public int EmployeeTitle_ID { get; set; }

        public int EmployeeRoleType_ID { get; set; }

        public int SecurityQuestion_ID { get; set; }

        public string Employee_Name { get; set; }

        public string Employee_Surname { get; set; }

        public string Employee_IDNumber { get; set; }

        public string Employee_ContactNumber { get; set; }

        public string Employee_EmailAddress { get; set; }

        public string Employee_HashedPassword { get; set; }

        public string Employee_SecurityQuestionAnswer { get; set; }
    }
}