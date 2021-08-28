using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediStockAPI.Controllers.Interviews
{
    public class FilterInterviewsController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("GetFilteredInterviews")]
        public IHttpActionResult getFilteredInterviews(int InterviewID)
        {

            try
            {
                var interviews = db.Interviews.ToList();
                List<InterviewVM> InterviewList = new List<InterviewVM>();

                foreach (var interview in interviews)
                {

                    if (interview.Interview_ID == InterviewID)
                    {
                        InterviewVM i = new InterviewVM();

                        i.Interview_ID = interview.Interview_ID;
                        i.InterviewType_ID = interview.InterviewType_ID;


                        InterviewList.Add(i);
                    }

                }

                return Ok(InterviewList);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }

}

