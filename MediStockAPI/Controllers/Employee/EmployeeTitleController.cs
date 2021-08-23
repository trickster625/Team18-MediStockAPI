using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers
{
    public class EmployeeTitleController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getEmployeeTitles")]
        public IHttpActionResult getEmployeeTitles()
        {
            try
            {
                List<EmployeeTitle> outputEmployeeTitle = new List<EmployeeTitle>();
                var storedEmployeeTitles = db.EmployeeTitles.ToList();

                foreach (var storedTitle in storedEmployeeTitles)
                {
                    EmployeeTitle title = new EmployeeTitle();
                    title.EmployeeTitle_ID = storedTitle.EmployeeTitle_ID;
                    title.EmployeeTitle_Description = storedTitle.EmployeeTitle_Description;
                    outputEmployeeTitle.Add(title);
                }

                return Ok(outputEmployeeTitle);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
}
}
