using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;
using System.Security.Cryptography;
using System.Text;
using System.IO;

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
               // var storedEmpRoles = db.Empl.ToList();
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
                        if (storedRoleType.RoleType_ID == emp.RoleType_ID)
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

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }


        [HttpPut]
        [Route("updateEmployee")]
        public IHttpActionResult updateEmployee(RegisterEmployee updateEmployee)
        {
            try
            {
                Models.Employee currentEmployee = new Models.Employee();
                currentEmployee = db.Employees.Where(z => z.Employee_ID == updateEmployee.Employee_ID).FirstOrDefault();

                currentEmployee.Employee_ID = updateEmployee.Employee_ID;
                currentEmployee.EmployeeTitle_ID = updateEmployee.EmployeeTitle_ID;
                currentEmployee.SecurityQuestion_ID = updateEmployee.SecurityQuestion_ID;
                currentEmployee.Employee_Name = updateEmployee.Employee_Name;
                currentEmployee.Employee_Surname = updateEmployee.Employee_Surname;
                currentEmployee.Employee_IDNumber = updateEmployee.Employee_IDNumber;
                currentEmployee.Employee_ContactNumber = updateEmployee.Employee_ContactNumber;
                currentEmployee.Employee_EmailAddress = updateEmployee.Employee_EmailAddress;
                currentEmployee.Employee_HashedPassword = Encrypt(updateEmployee.Employee_HashedPassword);
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
