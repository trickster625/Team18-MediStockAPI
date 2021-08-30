using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediStockAPI.Models.Login
{
    public class LoginVM
    {
        public int Employee_ID { get; set; }
        public string Token { get; set; }

        public LoginVM(Employee user, string token)
        {
            Employee_ID = user.Employee_ID;
            Token = token;
        }
    }
}