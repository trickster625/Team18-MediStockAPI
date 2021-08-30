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
    }
}
