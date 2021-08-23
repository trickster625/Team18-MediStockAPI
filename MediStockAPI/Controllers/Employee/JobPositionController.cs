using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers
{
    public class JobPositionController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getJobPositions")]
        public IHttpActionResult getJobPositions()
        {
            try
            {
                List<JobPosition> outputJobPosition = new List<JobPosition>();
                var storedJobPosition = db.JobPosition.ToList();

                foreach (var storedJobPosition in storedJobPositions)
                {
                    JobPosition position = new JobPosition();
                    position.JobPosition_ID = storedJobPosition.JobPosition_ID;
                    position.JobPosition_Description = storedJobPosition.JobPosition_Description;
                    outputJobPosition.Add(position);
                }

                return Ok(outputJobPosition);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
