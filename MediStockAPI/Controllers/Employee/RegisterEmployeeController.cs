using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers
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
                List<RegisterEmployee> outputEmployees = new List<RegisterEmployee>();

                var storedEmployees = db.Employees.ToList();
                var storedRoleTypes = db.RoleTypes.ToList();
                var storedTitle = db.EmployeeTitles.ToList();
                var storedQuestion = db.SecurityQuestions.ToList();

                foreach (var storedEmployee in storedEmployees)
                {
                    RegisterEmployee emp = new RegisterEmployee();

                    emp.Employee_ID = storedEmployee.Employee_ID;
                    emp.EmployeeTitle_ID = storedEmployee.EmployeeTitle_ID;
                    emp.SecurityQuestion_ID = storedEmployee.SecurityQuestion_ID;
                    emp.Employee_Name = storedEmployee.Employee_Name;
                    emp.Employee_Surname = storedEmployee.Employee_Surname;
                    emp.Employee_IDNumber = storedEmployee.Employee_IDNumber;
                    emp.Employee_ContactNumber = storedEmployee.Employee_ContactNumber;
                    emp.Employee_EmailAddress = storedEmployee.Employee_EmailAddress;
                    emp.Employee_HashedPassword = storedEmployee.Employee_HashedPassword;
                    emp.Employee_SecurityQuestionAnswer = storedEmployee.Employee_SecurityQuestionAnswer;
                    emp.Employee_SARSTaxNumber = storedEmployee.Employee_SARSTaxNumber;
                    emp.Employee_Signature = storedEmployee.Employee_Signature;

                    foreach (var storedRoleType in storedRoleTypes)
                    {
                        if (storedRoleType.RoleType_ID == storedRoleType.RoleType_ID)
                        {
                            emp.RoleType_Description = storedRoleType.RoleType_Description;
                        }
                    }

                    foreach (var storedTitles in storedTitle)
                    {
                        if (storedTitles.EmployeeTitle_ID == emp.EmployeeTitle_ID)
                        {
                            emp.EmployeeTitle_Description = storedTitles.EmployeeTitle_Description;
                        }
                    }

                    foreach (var storedQuestions in storedQuestion)
                    {
                        if (storedQuestions.SecurityQuestion_ID == emp.SecurityQuestion_ID)
                        {
                            emp.SecurityQuestion_Description = storedQuestions.SecurityQuestion_Description;
                        }
                    }


                    outputEmployees.Add(emp);
                }

                return Ok(outputEmployees);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getFilteredEmployees")]
        public IHttpActionResult getFilteredEmployees(string searchName, int searchTypeID)
        {

            try
            {
                var storedEmployees = db.Employees.ToList();
                var roletypes = db.RoleTypes.ToList();
                var titles = db.EmployeeTitles.ToList();
                var questions = db.SecurityQuestions.ToList();
                List<RegisterEmployee> EmployeeList = new List<RegisterEmployee>();

                foreach (var employee in storedEmployees)
                {

                    if (employee.Employee_Name == searchName)
                    {
                        RegisterEmployee emp = new RegisterEmployee();

                        emp.Employee_ID = employee.Employee_ID;
                        emp.EmployeeTitle_ID = employee.EmployeeTitle_ID;
                        emp.SecurityQuestion_ID = employee.SecurityQuestion_ID;
                        emp.Employee_Name = employee.Employee_Name;
                        emp.Employee_Surname = employee.Employee_Surname;
                        emp.Employee_IDNumber = employee.Employee_IDNumber;
                        emp.Employee_ContactNumber = employee.Employee_ContactNumber;
                        emp.Employee_EmailAddress = employee.Employee_EmailAddress;
                        emp.Employee_HashedPassword = employee.Employee_HashedPassword;
                        emp.Employee_SecurityQuestionAnswer = employee.Employee_SecurityQuestionAnswer;
                        emp.Employee_SARSTaxNumber = employee.Employee_SARSTaxNumber;
                        emp.Employee_Signature = employee.Employee_Signature;

                        foreach (var roletype in roletypes)
                        {
                            if (emp.RoleType_ID == roletype.RoleType_ID)
                            {
                                emp.RoleType_Description = roletype.RoleType_Description;
                            }
                        }


                        foreach (var title in titles)
                        {
                            if (emp.EmployeeTitle_ID == title.EmployeeTitle_ID)
                            {
                                title.EmployeeTitle_Description = title.EmployeeTitle_Description;
                            }
                        }

                        foreach (var question in questions)
                        {
                            if (emp.SecurityQuestion_ID == question.SecurityQuestion_ID)
                            {
                                question.SecurityQuestion_Description = question.SecurityQuestion_Description;
                            }
                        }


                        EmployeeList.Add(emp);
                    }

                }

                return Ok(EmployeeList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


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
                        return Ok(emp);
                    }

                }

                return Ok("No Match Found");
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("createEmployee")]
        public IHttpActionResult createEmployee(Employee newEmployee)
        {
            try
            {
                db.Employees.Add(newEmployee);
                db.SaveChangesAsync();

                return Ok("Employee Added!");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        [Route("updateEmployee")]
        public IHttpActionResult updateEmployee(RegisterEmployee updateEmployee)
        {
            try
            {
                Employee currentEmployee = new Employee();
                currentEmployee = db.Employees.Where(z => z.Employee_ID == updateEmployee.Employee_ID).FirstOrDefault();

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
                currentEmployee.Employee_SARSTaxNumber = updateEmployee.Employee_SARSTaxNumber;
                currentEmployee.Employee_Signature = updateEmployee.Employee_Signature;

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
                db.Employees.Remove(db.Employees.Single(z => z.Employee_ID == id));

                db.SaveChangesAsync();

                return Ok("Employee Deleted!");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
