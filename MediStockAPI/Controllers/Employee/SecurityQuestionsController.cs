using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Employee
{
    public class SecurityQuestionsController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getQuestions")]
        public IHttpActionResult getQuestions()
        {
            try
            {
                List<SecurityQuestion> outputQuestions = new List<SecurityQuestion>();
                var storedQuestions = db.SecurityQuestions.ToList();

                foreach (var storedQuestion in storedQuestions)
                {
                    SecurityQuestion question = new SecurityQuestion();

                    question.SecurityQuestion_ID = storedQuestion.SecurityQuestion_ID;
                    question.SecurityQuestion_Description = storedQuestion.SecurityQuestion_Description;

                    outputQuestions.Add(question);
                }

                outputQuestions = outputQuestions.OrderBy(z => z.SecurityQuestion_Description).ToList();
                return Ok(outputQuestions);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

        [HttpPost]
        [Route("createQuestion")]
        public IHttpActionResult createQuestion(SecurityQuestion newQuestion)
        {
            try
            {
                db.SecurityQuestions.Add(newQuestion);
                db.SaveChangesAsync();

                return Ok("Question Added");
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

        [HttpPut]
        [Route("updateQuestion")]
        public IHttpActionResult updateQuestion(SecurityQuestion updateQuestion)
        {
            try
            {
                SecurityQuestion currentQuestion = new SecurityQuestion();
                currentQuestion = db.SecurityQuestions.Where(z => z.SecurityQuestion_ID == updateQuestion.SecurityQuestion_ID).FirstOrDefault();

                currentQuestion.SecurityQuestion_Description = updateQuestion.SecurityQuestion_Description;
                db.SaveChangesAsync();

                return Ok("Question Updated!");
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

        [HttpDelete]
        [Route("deleteQuestion")]
        public IHttpActionResult deleteQuestion(int id)
        {
            try
            {
                db.SecurityQuestions.Remove(db.SecurityQuestions.Single(z => z.SecurityQuestion_ID== id));

                db.SaveChangesAsync();

                return Ok("Deleted");
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
