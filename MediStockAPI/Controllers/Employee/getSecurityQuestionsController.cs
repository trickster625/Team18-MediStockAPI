using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediStockAPI.Controllers
{
    public class getSecurityQuestionsController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getSecurityQuestions")]
        public IHttpActionResult getSecurityQuestions()
        {

            try
            {
                var securityQuestions = db.SecurityQuestions.ToList();
                List<SecurityQuestion> SecQuestionList = new List<SecurityQuestion>();

                foreach (var type in securityQuestions)
                {

                    SecurityQuestion securityQ = new SecurityQuestion();

                    securityQ.SecurityQuestion_ID = type.SecurityQuestion_ID;
                    securityQ.SecurityQuestion_Description = type.SecurityQuestion_Description;

                    SecQuestionList.Add(securityQ);

                }

                return Ok(SecQuestionList);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
