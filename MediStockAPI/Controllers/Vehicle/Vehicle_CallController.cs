using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MediStockAPI.Controllers.Vehicle
{
    public class Vehicle_CallController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();
        [HttpGet]
        [Route("getVehicleCalls")]
        public IHttpActionResult getVehicleCalls()
        {
            try
            {
                List<VehicleCall> vehicleCals = new List<VehicleCall>();

                var vehicleCalls = db.VehicleCalls.ToList();
                var storedWriteOffs = db.Written_OffInventory.ToList();

               foreach (var Storedcall in vehicleCalls)
                {
                    VehicleCall call = new VehicleCall();

                    call.Call_ID = Storedcall.Call_ID;
                    call.Employee_ID = Storedcall.Employee_ID;
                    call.Vehicle_ID = Storedcall.Vehicle_ID;
                    vehicleCals.Add(call);
                }

                return Ok(vehicleCals);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("GetVehicleCall")]
       
         public IHttpActionResult GetVehicleCall(int Search)
            {
                try
                {
                var result =db.VehicleCalls.Where(p => p.Call_ID == Search);

                return Ok(result);
                }
                catch (Exception err)
                {

                return BadRequest(err.ToString());
                }

            }

        [HttpPost]
        [Route("AddNewVehicleCall")]
        public async Task<IHttpActionResult> AddNewCancelReasonAsync(VehicleCall vehicleCall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid Data.");
            }

            using (var ctx = new MediStock_DBEntities())
            {
                ctx.VehicleCalls.Add(vehicleCall);
                await ctx.SaveChangesAsync();
            }
            return Ok("saved SuccesFully!");
        }

        //Updating Cancel Reason
        [HttpPut]
        [Route("UpdateVehicleCall")]
        public IHttpActionResult Put(VehicleCall vehicleCall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid call Reason.");
            }

            using (var ctx = new MediStock_DBEntities())
            {
                //Searches for Reason and sets it equal to variable using LINQ
                var existingCancelReason = ctx.VehicleCalls.Where(s => s.Call_ID == vehicleCall.Call_ID).FirstOrDefault<VehicleCall>();

                if (existingCancelReason != null)
                {
                    existingCancelReason.Call_ID = vehicleCall.Call_ID;
                    existingCancelReason.Vehicle_ID = vehicleCall.Vehicle_ID;
                    existingCancelReason.Employee_ID = vehicleCall.Employee_ID;

                    ctx.SaveChanges(); //saves changes to Database
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok("Saved Succesfully!");
        }






    }
}
