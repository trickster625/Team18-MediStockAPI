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

                    Candidate dropdownName = new Candidate();

                    dropdownName.Candidate_ID = name.Candidate_ID;
                    dropdownName.Candidate_Name = name.Candidate_Name;

                    nameList.Add(dropdownName);

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
