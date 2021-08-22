using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;
using MediStockAPI.Models.Employee.RegEmp;

namespace MediStockAPI.Controllers.Employee.RegisterEmp
{
    public class RegEmpController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getEmployees")]

        public IHttpActionResult getEmployees()
        {
            try
            {
                List<RegEmployee> outputEmployees = new List<RegEmployee>();

                var storedEmployees = db.Employees.ToList();
                var storedRoleTypes = db.RoleTypes.ToList();
                var storedTitle = db.EmployeeTitle.ToList();
                var storedQuestion = db.SecurityQuestion.ToList();

                foreach (var storedEmployee in storedEmployees)
                {
                    RegEmployee emp = new RegEmployee();

                    emp.Employee_ID = storedEmployees.Employee_ID;
                    emp.EmployeeTitle_ID = storedEmployees.EmployeeTitle_ID;
                    emp.SecurityQuestion_ID = storedEmployees.SecurityQuestion_ID;
                    emp.Employee_Name = storedEmployees.Employee_Name;
                    emp.Employee_Surname = storedEmployees.Employee_Surname;
                    emp.Employee_IDNumber = storedEmployees.Employee_IDNumber;
                    emp.Employee_ContactNumber = storedEmployees.Employee_ContactNumber;
                    emp.Employee_EmailAddress = storedEmployees.Employee_EmailAddress;
                    emp.Employee_HashedPassword = storedEmployees.Employee_HashedPassword;
                    emp.Employee_SecuirtyQuestionAsnwer = storedEmployees.Employee_SecuirtyQuestionAsnwer;
                    emp.Employee_SARSTaxNumber = storedEmployees.Employee_SARSTaxNumber;
                    emp.Employee_Signature = storedEmployees.Employee_Signature;

                    foreach (var storedRoleType in storedRoleTypes)
                    {
                        if (storedRoleType.RoleType_ID == storedRoleType.RoleType_ID)
                        {
                            emp.RoleType_Description = storedRoleType.RoleType_Description;
                        }
                    }

                    foreach (var storedTitles in storedTitle)
                    {
                        if (storedTitle.EmployeeTitle_ID == storedTitle.EmployeeTitle_ID)
                        {
                            emp.EmployeeTitle_Description = storedTitle.EmployeeTitle_Description;
                        }
                    }

                    foreach (var storedQuestions in storedQuestion)
                    {
                        if (storedQuestion.SecurityQuestion_ID == storedQuestion.SecurityQuestion_ID)
                        {
                            emp.SecurityQuestion_Description = storedQuestion.SecurityQuestion_Description;
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
                var employee = db.Employee.ToList();
                var roletypes = db.RoleTypes.ToList();
                var titles = db.EmployeeTitle.ToList();
                var questions = db.SecuirtyQuestion.ToList();
                List<RegEmployee> EmployeeList = new List<RegEmployee>();

                foreach (var storedEmployees in employee)
                {

                    if (emp.Employee_Name == searchName && emp.RoleType_ID == searchTypeID)
                    {
                        RegEmployee emp = new RegEmployee();

                        emp.Employee_ID = storedEmployees.Employee_ID;
                        emp.EmployeeTitle_ID = storedEmployees.EmployeeTitle_ID;
                        emp.SecurityQuestion_ID = storedEmployees.SecurityQuestion_ID;
                        emp.Employee_Name = storedEmployees.Employee_Name;
                        emp.Employee_Surname = storedEmployees.Employee_Surname;
                        emp.Employee_IDNumber = storedEmployees.Employee_IDNumber;
                        emp.Employee_ContactNumber = storedEmployees.Employee_ContactNumber;
                        emp.Employee_EmailAddress = storedEmployees.Employee_EmailAddress;
                        emp.Employee_HashedPassword = storedEmployees.Employee_HashedPassword;
                        emp.Employee_SecuirtyQuestionAsnwer = storedEmployees.Employee_SecuirtyQuestionAsnwer;
                        emp.Employee_SARSTaxNumber = storedEmployees.Employee_SARSTaxNumber;
                        emp.Employee_Signature = storedEmployees.Employee_Signature;

                        foreach (var roletype in roletypes)
                        {
                            if (emp.RoleType_ID == roletype.RoleType_ID)
                            {
                                employee.RoleType_Description = roletype.RoleType_Description;
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
                var emp = db.Employee.ToList();
                List<RegEmployee> EmployeeList = new List<RegEmployee>();
                RegEmployee emp = new RegEmployee();

                foreach (var emp in employee)
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
                        emp.Employee_SecuirtyQuestionAsnwer = storedEmployees.Employee_SecuirtyQuestionAsnwer;
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
        public IHttpActionResult createEmployee(Models.RegEmp newEmployee)
        {
            try
            {
                db.Employee.Add(newEmployee);
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
        public IHttpActionResult updateEmployee(Models.RegEmployee updateEmployee)
        {
            try
            {
                Models.RegEmployee currentEmployee = new Models.RegEmployee();
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
                currentEmployee.Employee_SecuirtyQuestionAsnwer = updateEmployee.Employee_SecuirtyQuestionAsnwer;
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
                db.Employee.Remove(db.Employee.Single(z => z.Employee_ID == id));

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
