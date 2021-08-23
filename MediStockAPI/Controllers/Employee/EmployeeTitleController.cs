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
                var storedEmployeeTitle = db.EmployeeTitle.ToList();

                foreach (var storedEmployeeTitle in storedEmployeeTitles)
                {
                    EmployeeTitle title = new EmployeeTitle();
                    title.Title_ID = storedEmployeeTitle.Title_ID;
                    title.Title_Description = storedEmployeeTitle.Title_Description;
                    outputJobPosition.Add(title);
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
