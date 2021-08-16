using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

                    Interview Interviews = new Interview();

                    Interviews.Interview_ID = i.Interview_ID;
                    Interviews.Candidate_ID = i.Candidate_ID;
                    Interviews.InterviewType_ID = i.InterviewType_ID;
                    Interviews.Employee_ID = i.Employee_ID;
                    Interviews.ScheduledDate_Time = i.ScheduledDate_Time;
                    Interviews.InterviewMethod = i.InterviewMethod;
                    Interviews.Address = i.Address;

                    InterviewList.Add(Interviews);

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
            catch (Exception)
            {
                return BadRequest();
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


                currentInterview.Interview_ID = updatedInterview.Interview_ID;
                currentInterview.InterviewType = updatedInterview.InterviewType;
                currentInterview.InterviewType_ID = updatedInterview.InterviewType_ID;
                currentInterview.InterviewMethod = updatedInterview.InterviewMethod;

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
