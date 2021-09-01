using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediStockAPI.Controllers
{
    public class getCurrentEmployeeController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();
        [HttpGet]
        [Route("getcurrentEmployee")]
        public IHttpActionResult getcurrenEmployee(int id)
        {

            try
            {
                var storedEmployee = db.Employees.ToList();
                List<RegisterEmployee> EmployeeList = new List<RegisterEmployee>();
                RegisterEmployee emp = new RegisterEmployee();

                foreach (var storedEmployees in storedEmployee)
                {

                    if (emp.Employee_ID == id)
                    {
                        emp.Employee_ID = storedEmployees.Employee_ID;
                        emp.EmployeeTitle_ID = storedEmployees.EmployeeTitle_ID;
                        emp.SecurityQuestion_ID = storedEmployees.SecurityQuestion_ID;
                        emp.Employee_Name = storedEmployees.Employee_Name;
                        emp.Employee_Surname = storedEmployees.Employee_Surname;
                        emp.Employee_IDNumber = storedEmployees.Employee_IDNumber;
                        emp.Employee_ContactNumber = storedEmployees.Employee_ContactNumber;
                        emp.Employee_EmailAddress = storedEmployees.Employee_EmailAddress;
                        emp.Employee_HashedPassword = storedEmployees.Employee_HashedPassword;
                        emp.Employee_SecurityQuestionAnswer = storedEmployees.Employee_SecurityQuestionAnswer;
                        emp.Employee_SARSTaxNumber = storedEmployees.Employee_SARSTaxNumber;
                        emp.Employee_Signature = storedEmployees.Employee_Signature;
                    }

                }

                return Ok(emp);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
