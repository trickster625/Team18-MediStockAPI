using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;
using MediStockAPI.Models.ReportingVM;

namespace MediStockAPI.Controllers.Reporting
{
    public class CallLogController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpPost]
        [Route("getCallLogs")]
        public IHttpActionResult getCallLogs(callLogDatesVM dates)
        {
            try
            {
                List<callLogOutputVM> outputLogs = new List<callLogOutputVM>();

                var storedCalls = db.Calls.Where(z => z.Call_Date >= dates.startDateRange && z.Call_Date <= dates.endDateRange).ToList();
                var storedCallStatusses = db.CallStatus.ToList();

                foreach (var call in storedCalls)
                {
                    callLogOutputVM outputLog = new callLogOutputVM();

                    outputLog.Call_ID = call.Call_ID;
                    outputLog.CallStatus_ID = call.CallStatus_ID;

                    foreach (var status in storedCallStatusses)
                    {
                        if (call.CallStatus_ID == status.CallStatus_ID)
                        {
                            outputLog.CallStatus_Description = status.CallStatus_Description;
                        }
                    }

                    outputLogs.Add(outputLog);

                }
                
                return Ok(outputLogs);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
