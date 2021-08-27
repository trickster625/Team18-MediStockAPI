using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;
using MediStockAPI.Models.ReportingVM;

namespace MediStockAPI.Controllers.Reporting
{
    public class JobApplicationsReportController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getJobApplicationsReport")]
        public IHttpActionResult getJobApplicationsReport()
        {
            try
            {
                List<JobApplicationReportVM> outputApplications = new List<JobApplicationReportVM>();
                var storedApplications = db.JobApplications.ToList();
                var storedPositions = db.JobPositions.ToList();

                foreach (var storedApplication in storedApplications)
                {
                    JobApplicationReportVM application = new JobApplicationReportVM();

                    application.Position_ID = storedApplication.Position_ID;
                    application.shortListed = (bool)storedApplication.Shortlisted;    

                    foreach (var storedPosition in storedPositions)
                    {
                        if (storedPosition.Position_ID == storedApplication.Position_ID)
                        {
                            application.Position_Description = storedPosition.Position_Description;
                        }
                    }

                    outputApplications.Add(application);
                }

                return Ok(outputApplications);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
