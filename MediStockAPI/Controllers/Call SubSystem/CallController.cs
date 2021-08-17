using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Call_SubSystem
{
    public class CallController : ApiController
    {
        
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("GetAllCalls")]
        public IHttpActionResult GetCalls()
        {
            try
            {
                IList<CallVM> calls = null;

                using (var ctx = new MediStock_DBEntities())
                {
                    calls = db.Calls.Select(s => new CallVM()
                    {
                        Call_ID = s.Call_ID,
                        Reason_ID = s.Reason_ID,
                        CallStatus_ID = s.CallStatus_ID,
                        Call_Date = (DateTime)s.Call_Date,
                        Call_StartTime = (TimeSpan)s.Call_StartTime,
                        Call_EndTime = (TimeSpan)s.Call_EndTime,
                        PRF_Number = (int)((s.PRF_Number == null) ? 0 : s.PRF_Number),
                        DOA_Number = (int)((s.DOA_Number == null) ? 0 : s.DOA_Number)
                    }).ToList<CallVM>();
                }
                
                return Ok(calls);
           }
           catch (Exception)
           {
                
                return BadRequest("not working :-(");
          }
        }

        [HttpGet]
        [Route("GetPendingCalls")]
        
        public IEnumerable<Call> GetPendingCalls()
        {
            try
            {
                return (IEnumerable<Call>)db.Calls.Where(p => p.CallStatus_ID == 2);
                //IList<CallVM> calls = null;
                //IList<CallVM> newCalls = null;
                //using (var ctx = new MediStock_DBEntities())
                //{
                //    calls = db.Calls.Select(s => new CallVM()
                //    {
                //        Call_ID = s.Call_ID,
                //        Reason_ID = s.Reason_ID,
                //        CallStatusID = s.CallStatus_ID,
                //        Call_Date = (DateTime)s.Call_Date,
                //        Call_StartTime = (TimeSpan)s.Call_StartTime,
                //        Call_EndTime = (TimeSpan)s.Call_EndTime,
                //        PRF_Number = (int)((s.PRF_Number == null) ? 0 : s.PRF_Number),
                //        DOA_Number = (int)((s.DOA_Number == null) ? 0 : s.DOA_Number)
                //    }).ToList<CallVM>();

                //    IEnumerable<CallVM> query = calls.Where(call => call.CallStatusID == 2);

                //    foreach (var call in query)
                //    {
                //        newCalls.Add(call);
                //    }
                //}
                //return Ok(newCalls);
            }
            catch (Exception)
            {
                throw;
                //return BadRequest("notWorking");
               
            }
        }


        [HttpGet]
        [Route("SearchCall")]

        public IEnumerable<Call> GetSearchCall(int Search)
        {
            try
            {
                return (IEnumerable<Call>)db.Calls.Where(p => p.Call_ID == Search || p.DOA_Number == Search || p.PRF_Number == Search);
            }
            catch (Exception)
            {
               
                throw;
            }
            
        }

        [HttpPut]
        [Route ("UpdateCall")]
        public IHttpActionResult UpdateCall(Call call)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid call");
            }

            using(var ctx = new MediStock_DBEntities())
            {
                var existingcall = ctx.Calls.Where(s => s.Call_ID == call.Call_ID).FirstOrDefault();

                if (existingcall != null)
                {
                    existingcall.Call_ID = call.Call_ID;
                    existingcall.Reason_ID = call.Reason_ID;
                    existingcall.CallStatus_ID = call.CallStatus_ID;
                    existingcall.Call_Date = call.Call_Date;
                    existingcall.Call_StartTime = call.Call_StartTime;
                    existingcall.Call_EndTime = call.Call_EndTime;
                    existingcall.PRF_Number = call.PRF_Number;
                    existingcall.DOA_Number = call.DOA_Number;

                     ctx.SaveChanges();

                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }


        [HttpPost]
        [Route("CreateCall")]
        public IHttpActionResult CreateCall(Call call)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid data");
                }

                using(var ctx = new MediStock_DBEntities())
                {
                    ctx.Calls.Add(new Call()
                    {
                        Call_ID = call.Call_ID,
                        Reason_ID = call.Reason_ID,
                        CallStatus_ID = call.CallStatus_ID,
                        Call_Date = call.Call_Date,
                        Call_StartTime = call.Call_StartTime,
                        Call_EndTime = call.Call_EndTime,
                        PRF_Number = call.PRF_Number,
                        DOA_Number = call.DOA_Number

                    }) ;

                    ctx.SaveChangesAsync();
                }
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
