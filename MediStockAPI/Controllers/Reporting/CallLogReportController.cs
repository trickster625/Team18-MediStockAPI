using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Reporting
{
    public class CallLogReportController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getCalls")]
        public IHttpActionResult getCalls()
        {
            try
            {
                List<Call> outputCalls = new List<Call>();
                var storedCalls = db.Call.ToList();

                foreach (var storedCalls in storedCalls)
                {
                    storedCalls calls = new storedCalls();
                    call.Call_ID = storedCalls.Call_ID;
                    call.Call_Date = storedCalls_Date;
                    outputCalls.Add(call);
                }

                return Ok(outputCalls);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
}
