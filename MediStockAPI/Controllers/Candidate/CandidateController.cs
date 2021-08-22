using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;


namespace MediStockAPI.Controllers.Candidate
{
    public class CandidateController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getCandidates")]
        public IHttpActionResult getCandidates()
        {
            try
            {
                List<Candidate> outputItems = new List<Candidate>();

                var storedItems = db.Candidates.ToList();

                foreach (var storedItem in storedItems)
                {
                    Candidate item = new Candidate();

                    item.Candidate_ID = storedItem.Candidate_ID;
                    item.Candidate_Name = storedItem.Candidate_Name;
                    item.Candidate_Surname = storedItem.Candidate_Surname;
                    item.Candidate_Email = storedItem.Candidate_Email;
                    item.Candidate_ContactNumber = storedItem.Candidate_ContactNumber;
                    item.Candidate_CVFile = storedItem.Candidate_CVFile;

                    outputItems.Add(item);
                }

                return Ok(outputItems);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("createCandidate")]
        public IHttpActionResult createCandidate(Models.Candidate newCandidateItem)
        {
            try
            {
                db.Candidates.Add(newCandidateItem);
                db.SaveChangesAsync();

                return Ok("Candidate Added");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("ViewCandidate")]
        public IHttpActionResult viewCandidate(Models.Candidate viewCandidate)
        {
            try
            {
                Models.Candidate currentCandidate = new Models.Candidate();
                currentCandidate = db.Candidate.Where(z => z.Candidate_ID == viewCandidate.Candidate_ID).FirstOrDefault();

                currentCandidate.Candidate_ID = viewCandidate.Candidate_ID;
                currentCandidate.Candidate_Name = viewCandidate.Candidate_Name;
                currentCandidate.Candidate_Surname = viewCandidate.Candidate_Surname;
                currentCandidate.Candidate_Email = viewCandidate.Candidate_Email;
                currentCandidate.Candidate_ContactNumber = viewCandidate.Candidate_ContactNumber;
                currentCandidate.Candidate_CVFile = viewCandidate.Candidate_CVFile;

                db.SaveChangesAsync();

                return Ok("Candidate Updated!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // questionable
        [HttpDelete]
        [Route("acceptCandidate")]
        public IHttpActionResult acceptCandidate(int id)
        {
            try
            {
                db.Candidate.Accept(db.Candidate.Single(z => z.Candidate_ID == id));

                db.SaveChangesAsync();

                return Ok("Accepted");
                // add to db.JobApplication shortlist
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
