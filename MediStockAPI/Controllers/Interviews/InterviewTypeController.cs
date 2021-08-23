using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediStockAPI.Controllers
{
    public class InterviewTypeController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("GetInterviewTypes")]
        public IHttpActionResult GetInterviewTypes()
        {
            try
            {
                var types = db.InterviewTypes.ToList();
                List<InterviewType> typeList = new List<InterviewType>();

                foreach (var item in types)
                {

                    InterviewType dropdownType = new InterviewType();

                    dropdownType.InterviewType_ID = item.InterviewType_ID;
                    dropdownType.InterviewType_Description = item.InterviewType_Description;

                    typeList.Add(dropdownType);

                }

                return Ok(typeList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}