using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediStockAPI.Controllers.Interviews
{
    public class GetCurrentInterviewController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("GetCurrentInterview")]
        public IHttpActionResult getCurrentInterview(int id)
        {

            try
            {
                var interview = db.Interviews.ToList();
                List<Interview> interviewList = new List<Interview>();

                foreach (var i in interview)
                {

                    Interview Interview = new Interview();

                    if (i.Interview_ID == id)
                    {

                        Interview.Interview_ID = i.Interview_ID;
                        Interview.Candidate_ID = i.Candidate_ID;
                        Interview.InterviewType_ID = i.InterviewType_ID;
                        Interview.Employee_ID = i.Employee_ID;
                        Interview.SheduleDateTime = i.SheduleDateTime;
                        Interview.InterviewMethod = i.InterviewMethod;
                        Interview.Address = i.Address;

                    }

                    interviewList.Add(Interview);

                }

                return Ok(interviewList);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}

