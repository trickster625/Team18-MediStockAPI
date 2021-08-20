using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;
using System.Web.Http.Cors;

namespace MediStockAPI.Controllers
{
    public class JobPositionController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("getJobPositions")]

        public IHttpActionResult getJobPositions()
        {
            try
            {
                List<JobPositionVM> outputJobs = new List<JobPositionVM>();

                var storedJobs = db.JobPositions.ToList();
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
                        if(storedJob.RoleType_ID == storedRoleType.RoleType_ID)
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
        }

        [HttpGet]
        [Route("getFilteredJobs")]
        public IHttpActionResult getFilteredJobs(string searchName, int searchTypeID)
        {

            try
            {
                var jobs = db.JobPositions.ToList();
                var roletypes = db.RoleTypes.ToList();
                List<JobPositionVM> JobList = new List<JobPositionVM>();

                foreach (var job in jobs)
                {

                    if (job.Position_Description == searchName && job.RoleType_ID == searchTypeID)
                    {
                        JobPositionVM jobPosition = new JobPositionVM();

                        jobPosition.Position_ID = job.Position_ID;
                        jobPosition.Position_Description = job.Position_Description;
                        jobPosition.RoleType_ID = job.RoleType_ID;

                        foreach (var roletype in roletypes)
                        {
                            if (job.RoleType_ID == roletype.RoleType_ID)
                            {
                                jobPosition.RoleType_Description = roletype.RoleType_Description;
                            }
                        }

                        JobList.Add(jobPosition);
                    }

                }

                return Ok(JobList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getCurrentJob")]
        public IHttpActionResult getCurrentJob(int id)
        {

            try
            {
                var jobs = db.JobPositions.ToList();
                List<JobPositionVM> JobList = new List<JobPositionVM>();
                JobPositionVM currentJob = new JobPositionVM();

                foreach (var job in jobs)
                {

                    if (job.Position_ID == id)
                    {
                        currentJob.Position_ID = id;
                        currentJob.Position_Description = job.Position_Description;
                        currentJob.RoleType_ID = job.RoleType_ID;
                        currentJob.Position_Compensation = (decimal)job.Position_Compensation;
                        return Ok(currentJob);
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
        [Route("createJobPosition")]
        public IHttpActionResult createJobPosition(Models.JobPosition newJobPosition)
        {
            try
            {
                db.JobPositions.Add(newJobPosition);
                db.SaveChangesAsync();

                return Ok("Job Position Added!");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        [Route("updateJobPosition")]
        public IHttpActionResult updateJobPosition(Models.JobPosition updateJobPosition)
        {
            try
            {
                Models.JobPosition currentJobPosition = new Models.JobPosition();
                currentJobPosition = db.JobPositions.Where(z => z.Position_ID == updateJobPosition.Position_ID).FirstOrDefault();

                currentJobPosition.RoleType_ID = updateJobPosition.RoleType_ID;
                currentJobPosition.Position_Description = updateJobPosition.Position_Description;
                currentJobPosition.Position_Compensation = updateJobPosition.Position_Compensation;
                //currentJobPosition.Position_Date = updateJobPosition.Position_Date;

                db.SaveChangesAsync();

                return Ok("Job Position Updated!");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("deleteJobPosition")]
        public IHttpActionResult deleteJobPosition(int id)
        {
            try
            {
                db.JobPositions.Remove(db.JobPositions.Single(z => z.Position_ID == id));

                db.SaveChangesAsync();

                return Ok("Job Position Deleted!");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
