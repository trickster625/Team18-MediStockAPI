using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers
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
                List<Candidate> outputCandidates = new List<Candidate>();

                var storedCandidates = db.Candidates.ToList();

                foreach (var storedCandidate in storedCandidates)
                {
                    Candidate candidate = new Candidate();

                    candidate.Candidate_ID = storedCandidate.Candidate_ID;
                    candidate.Candidate_Name = storedCandidate.Candidate_Name;
                    candidate.Candidate_Surname = storedCandidate.Candidate_Surname;
                    candidate.Candidate_Email = storedCandidate.Candidate_Email;
                    candidate.Candidate_ContactNumber = storedCandidate.Candidate_ContactNumber;
                    candidate.Candidate_CVFile = storedCandidate.Candidate_CVFile;

                    outputCandidates.Add(candidate);
                }

                return Ok(outputCandidates);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("createCandidate")]
        public IHttpActionResult createCandidate(Candidate newCandidateItem)
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
        public IHttpActionResult viewCandidate(Candidate viewCandidate)
        {
            try
            {
                Candidate currentCandidate = new Candidate();
                currentCandidate = db.Candidates.Where(z => z.Candidate_ID == viewCandidate.Candidate_ID).FirstOrDefault();

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
    }
}
