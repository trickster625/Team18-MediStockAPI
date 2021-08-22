using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.EmpShift
{
    public class ShiftController : ApiController
    {
        /*
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getShifts")]

        public IHttpActionResult getShifts()
        {
            try
            {
                List<ShiftVM> outputJobs = new List<ShiftVM>();

                var storedShifts = db.Shfits.ToList();
                var storedRoleTypes = db.RoleTypes.ToList();

                foreach (var storedJob in storedJobs)
                {
                    JobPositionVM job = new JobPositionVM();

                    job.Position_ID = storedJob.Position_ID;
                    job.RoleType_ID = storedJob.RoleType_ID;
                    job.Position_Description = storedJob.Position_Description;
                    //job.Position_Compensation = (decimal)storedJob.Position_Compensation;
                    //job.Position_Date = (DateTime)storedJob.Position_Date;

                    foreach (var storedRoleType in storedRoleTypes)
                    {
                        if (storedJob.RoleType_ID == storedRoleType.RoleType_ID)
                        {
                            job.RoleType_Description = storedRoleType.RoleType_Description;
                        }
                    }

                    outputJobs.Add(job);
                }

                return Ok(outputJobs);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        } */
    }
}
