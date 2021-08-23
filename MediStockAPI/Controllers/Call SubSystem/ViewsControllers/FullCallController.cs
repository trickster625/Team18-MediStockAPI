using MediStockAPI.Models;
using MediStockAPI.Models.Views_VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediStockAPI.Controllers.Call_SubSystem.ViewsControllers
{
    public class FullCallController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();


        //Get Method for FUll Calls View
        [HttpGet]
        [Route("GetFullCalls")]
        public IHttpActionResult GetCalls()
        {
            try
            {
                IList<FullCallVM> calls = null;

                using (var ctx = new MediStock_DBEntities())
                {
                    calls = db.FullCalls.Select(s => new FullCallVM()
                    {
                        Call_ID = s.Call_ID,
                        Reason_ID = s.Reason_ID,
                        CallStatus_ID = s.CallStatus_ID,
                        Call_Date = (DateTime)s.Call_Date,
                        Call_StartTime = (TimeSpan)s.Call_StartTime,
                        Call_EndTime = (TimeSpan)s.Call_EndTime,
                        PRF_Number = (int)((s.PRF_Number == null) ? 0 : s.PRF_Number),
                        DOA_Number = (int)((s.DOA_Number == null) ? 0 : s.DOA_Number),
                        Reason_Description = s.Reason_Description,
                        CallStatus_Description = s.CallStatus_Description,
                        Employee_ID = s.Employee_ID,
                        Employee_Surname = s.Employee_Surname

                    }).ToList<FullCallVM>();
                }

                return Ok(calls);
            }
            catch (Exception)
            {

                return BadRequest("not working :-(");
            }
        }

        //Search Call Based on CAll_ID

        [HttpGet]
        [Route("SearchFullCall")]

        public IEnumerable<FullCall> GetSearchCall(int Search)
        {
            try
            {
                return (IEnumerable<FullCall>) db.FullCalls.Where(p => p.Call_ID == Search);
                                   
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
