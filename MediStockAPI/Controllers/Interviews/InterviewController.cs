using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace MediStockAPI.Controllers
{
    public class InterviewController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("GetInterviews")]
        public IHttpActionResult getInterviews()
        {

            try
            {
                var interviews = db.Interviews.ToList();
                List<Interview> InterviewList = new List<Interview>();

                 foreach (var i in interviews)
                {

                    Interview interview = new Interview();

                    interview.Interview_ID = i.Interview_ID;
                    interview.Candidate_ID = i.Candidate_ID;
                    interview.InterviewType_ID = i.InterviewType_ID;
                    interview.Employee_ID = i.Employee_ID;
                    interview.SheduleDateTime = i.SheduleDateTime;
                    interview.InterviewMethod = i.InterviewMethod;
                    interview.Address = i.Address;

                    InterviewList.Add(interview);
                }

                return Ok(InterviewList);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("PostCreateInterview")]
        public IHttpActionResult PostCreateInterview(Interview interview)
        {

            try
            {
                db.Interviews.Add(interview);
                db.SaveChangesAsync();

                return Ok("Interview Scheduled");
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }

        }

        [HttpDelete]
        [Route("DeleteInterview")]
        public IHttpActionResult deleteInterview(int id)
        {
            try
            {
                db.Interviews.Remove(db.Interviews.Single(z => z.Interview_ID == id));

                db.SaveChangesAsync();

                return Ok("Interview Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateInterview")]
        public IHttpActionResult updateInterview(Interview updatedInterview)

        {
            try
            {
                Interview currentInterview = new Interview();
                currentInterview = db.Interviews.Where(z => z.Interview_ID == updatedInterview.Interview_ID).FirstOrDefault();
                currentInterview.InterviewType_ID = updatedInterview.InterviewType_ID;
                currentInterview.Interview_ID = updatedInterview.Interview_ID;
                currentInterview.Candidate_ID = updatedInterview.Candidate_ID;
                currentInterview.Employee_ID = updatedInterview.Employee_ID;
                currentInterview.SheduleDateTime = updatedInterview.SheduleDateTime;
                currentInterview.InterviewMethod = updatedInterview.InterviewMethod;
                currentInterview.Address = updatedInterview.Address;

                db.SaveChangesAsync();

                return Ok("Interview Updated");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
