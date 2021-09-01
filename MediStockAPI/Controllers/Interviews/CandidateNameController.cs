using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediStockAPI.Controllers
{
    public class CandidateNameController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("GetCandidateNames")]
        public IHttpActionResult getCandidateNames()
        {
            try
            {
                var cNames = db.Candidates.ToList();
                List<Candidate> nameList = new List<Candidate>();

                foreach (var name in cNames)
                {

                    Candidate candidateInfo = new Candidate();

                    candidateInfo.Candidate_ID = name.Candidate_ID;
                    candidateInfo.Candidate_Name = name.Candidate_Name;
                    candidateInfo.Candidate_Surname = name.Candidate_Surname;
                    candidateInfo.Candidate_Email = name.Candidate_Email;
                    candidateInfo.Candidate_ContactNumber = name.Candidate_ContactNumber;
                    candidateInfo.Candidate_CVFile = name.Candidate_CVFile;

                    nameList.Add(candidateInfo);

                }

                return Ok(nameList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateCandidate")]
        public IHttpActionResult updateCandidate(Candidate updatedCandidate)

        {
            try
            {
                Candidate currentCandidate = new Candidate();
                currentCandidate = db.Candidates.Where(z => z.Candidate_ID == updatedCandidate.Candidate_ID).FirstOrDefault();
                currentCandidate.Candidate_ID = updatedCandidate.Candidate_ID;
                currentCandidate.Candidate_Name = updatedCandidate.Candidate_Name;
                currentCandidate.Candidate_Surname = updatedCandidate.Candidate_Surname;
                currentCandidate.Candidate_Email = updatedCandidate.Candidate_Email;
                currentCandidate.Candidate_CVFile = updatedCandidate.Candidate_CVFile;
                currentCandidate.Candidate_ContactNumber = updatedCandidate.Candidate_ContactNumber;

                db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
