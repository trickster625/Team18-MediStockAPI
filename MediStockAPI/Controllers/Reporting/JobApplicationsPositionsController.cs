using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Reporting
{
    public class JobApplicationsPositionsController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getJobApplicationsPositions")]
        public IHttpActionResult getJobApplicationsPositions()
        {
            try
            {
                List<JobPosition> outputPositions = new List<JobPosition>();
                var storedPositions = db.JobPositions.ToList();

                foreach (var storedPosition in storedPositions)
                {
                    JobPosition position = new JobPosition();

                    position.Position_ID = storedPosition.Position_ID;
                    position.Position_Description = storedPosition.Position_Description;

                    outputPositions.Add(position);
                }

                return Ok(outputPositions);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
