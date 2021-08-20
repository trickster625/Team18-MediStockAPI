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
                List<Employee> nameList = new List<Employee>();

                foreach (var name in eNames)
                {

                    Employee dropdownName = new Employee();

                    dropdownName.Employee_ID = name.Employee_ID;
                    dropdownName.Employee_Name = name.Employee_Name;

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
