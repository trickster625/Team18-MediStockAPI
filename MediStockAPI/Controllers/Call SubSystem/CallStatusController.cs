using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediStockAPI.Controllers.Call_SubSystem
{
    public class CallStatusController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("GetCallStatus")]
        public IHttpActionResult getallCallStatus()
        {

            try
            {
                var roleTypes = db.RoleTypes.ToList();

                var Statuses = db.CallStatus.ToList();

                List<RoleType> RoleTypeList = new List<RoleType>();

                List<CallStatu> Statuseslist = new List<CallStatu>();

                foreach (var type in Statuses)
                {

                   
                    CallStatu callStatus = new CallStatu();

                    callStatus.CallStatus_ID = type.CallStatus_ID;
                    callStatus.CallStatus_Description = type.CallStatus_Description;

                    Statuseslist.Add(callStatus);

                    

                }

                return Ok(RoleTypeList);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

       


    }
}
