using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediStockAPI.Controllers
{
    public class EmployeeNameController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("GetEmployeeNames")]
        public IHttpActionResult getEmployeeNames()
        {
            try
            {
                var eNames = db.Employees.ToList();
                List<Models.Employee> nameList = new List<Models.Employee>();

                foreach (var name in eNames)
                {

                    Models.Employee dropdownName = new Models.Employee();

                    dropdownName.Employee_ID = name.Employee_ID;
                    dropdownName.EmployeeTitle_ID = name.EmployeeTitle_ID;
                    dropdownName.SecurityQuestion_ID = name.SecurityQuestion_ID;
                    dropdownName.Employee_Name = name.Employee_Name;
                    dropdownName.Employee_Surname = name.Employee_Surname;
                    dropdownName.Employee_IDNumber = name.Employee_IDNumber;
                    dropdownName.Employee_ContactNumber = name.Employee_ContactNumber;
                    dropdownName.Employee_EmailAddress = name.Employee_EmailAddress;
                    dropdownName.Employee_HashedPassword = name.Employee_HashedPassword;
                    dropdownName.Employee_SecurityQuestionAnswer = name.Employee_SecurityQuestionAnswer;
                    dropdownName.Employee_SARSTaxNumber = name.Employee_SARSTaxNumber;
                    dropdownName.Employee_Signature = name.Employee_Signature;

                    nameList.Add(dropdownName);

                }

                return Ok(nameList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
