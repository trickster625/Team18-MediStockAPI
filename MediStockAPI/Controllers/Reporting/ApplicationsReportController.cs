using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Reporting
{
    public class ApplicationsController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getApplications")]
        public IHttpActionResult getApplications()
        {
            try
            {
                List<JobApplication> outputJobApplications = new List<JobApplication>();
                var storedJobApplications = db.JobApplications.ToList();

                foreach (var storedJobApplications in storedJobApplications)
                {
                    storedJobApplication jobapplication = new storedJobApplication();
                    jobapplication.Position_ID = storedJobApplication.Position_ID;
                    jobapplication. = storedJobApplication.;
                    outputJobApplications.Add(application);
                }

                return Ok(outputJobApplications);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
