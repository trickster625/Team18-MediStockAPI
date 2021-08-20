using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Employee
{
    public class RegisterEmployeeController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getEmployees")]
        public IHttpActionResult getEmployees()
        {
            try
            {
                List<Employee> outputItems = new List<Employee>();
                
                var storedItems = db.Employees.ToList();
                
                foreach (var storedItem in storedItems)
                {
                    Employee item = new Employee();           

                    item.Employee_ID = storedItem.Employee_ID;
                    item.EmployeeTitle_ID = storedItem.EmployeeTitle_ID;
                    item.SecurityQuestion_ID = storedItem.SecurityQuestion_ID;
                    item.Employee_Name = storedItem.Employee_Name;
                    item.Employee_Surname = storedItem.Employee_Surname;
                    item.Employee_IDNumber = storedItem.Employee_IDNumber;
                    item.Employee_ContactNumber = storedItem.Employee_ContactNumber;
                    item.Employee_EmailAddress = storedItem.Employee_EmailAddress;
                    item.Employee_HashedPassword = storedItem.Employee_HashedPassword;
                    item.Employee_SecurityQuestionAnswer = storedItem.Employee_SecurityQuestionAnswer;

                    outputItems.Add(item);
                }

                return Ok(outputItems);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("createEmployee")]
        public IHttpActionResult createEmployee(Models.Employee newEmployeeItem)
        {
            try
            {
                db.Employee.Add(newEmployeeItem);
                db.SaveChangesAsync();

                return Ok("Employee Added");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("updateEmployee")]
        public IHttpActionResult updateEmployee(Models.Employee updateEmployee)
        {
            try
            {
                Models.Employee currentEmployee = new Models.Employee();
                currentEmployee = db.Employee.Where(z => z.Employee_ID == updateEmployee.Employee_ID).FirstOrDefault();

                currentEmployee.Employee_ID = updateEmployee.Employee_ID;
                currentEmployee.EmployeeTitle_ID = updateEmployee.EmployeeTitle_ID;
                currentEmployee.SecurityQuestion_ID = updateEmployee.SecurityQuestion_ID;
                currentEmployee.Employee_Name = updateEmployee.Employee_Name;
                currentEmployee.Employee_Surname = updateEmployee.Employee_Surname;
                currentEmployee.Employee_IDNumber = updateEmployee.Employee_IDNumber;
                currentEmployee.Employee_ContactNumber = updateEmployee.Employee_ContactNumber;
                currentEmployee.Employee_EmailAddress = updateEmployee.Employee_EmailAddress;
                currentEmployee.Employee_HashedPassword = updateEmployee.Employee_HashedPassword;
                currentEmployee.Employee_SecurityQuestionAnswer = updateEmployee.Employee_SecurityQuestionAnswer;

                db.SaveChangesAsync();

                return Ok("Employee Updated!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("deleteEmployee")]
        public IHttpActionResult deleteEmployee(int id)
        {
            try
            {
                db.Employee.Remove(db.Employee.Single(z => z.Employee_ID == id));

                db.SaveChangesAsync();

                return Ok("Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}