using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MediStockAPI.Controllers.Call_SubSystem
{
    public class CancelReasonController : ApiController
    {
        [HttpGet]
        [Route("GetAllCancelReasons")]

        //Get to find all cancel reasons
        public IHttpActionResult GetAllCancelReasons()
        {
            IList<CallCancelReasonsVM> Reasons = null;  
            using (var ctx = new MediStock_DBEntities())
            {
                
                Reasons = ctx.CallCancelReasons.Select(s => new CallCancelReasonsVM()
                {
                    Reason_ID = s.Reason_ID,
                    Reason_Description = s.Reason_Description
                   
                }).ToList<CallCancelReasonsVM>();

            }
            if (Reasons.Count == 0 )
            {
                return NotFound();
            }
            return Ok(Reasons);
                
        }
        MediStock_DBEntities db = new MediStock_DBEntities();
        //Get to find Cancel Reason 
        [HttpGet]
        [Route("FindCancelReason")]

        public IEnumerable<CallCancelReason> getFindCancelReason(string CancelReason)
        {
            return (IEnumerable<CallCancelReason>)db.CallCancelReasons.Where(p => p.Reason_Description.Contains(CancelReason));
        }


        //Adding New Cancel Reason
        [HttpPost]
        [Route("AddNewCancelReason")]
        public async Task<IHttpActionResult> AddNewCancelReasonAsync(CallCancelReason callCancelReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid Data.");
            }

            using(var ctx = new MediStock_DBEntities())
            {
                ctx.CallCancelReasons.Add(callCancelReason);
                await ctx.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpPost]
        [Route("TestAddNewReason")]
        public IHttpActionResult createBarcode(Barcode newBarcode)
        {
            try
            {
                db.Barcodes.Add(newBarcode);
                db.SaveChangesAsync();

                return Ok("Barcode Added");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Updating Cancel Reason
        [HttpPut]
        [Route("UpdateCancelReason")]
        public IHttpActionResult Put(CallCancelReason callCancelReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid call Reason.");
            }

            using(var ctx = new MediStock_DBEntities())
            {
                //Searches for Reason and sets it equal to variable using LINQ
                var existingCancelReason = ctx.CallCancelReasons.Where(s => s.Reason_ID == callCancelReason.Reason_ID).FirstOrDefault<CallCancelReason>();

                if (existingCancelReason!= null)
                {
                    existingCancelReason.Reason_ID = callCancelReason.Reason_ID;
                    existingCancelReason.Reason_Description = callCancelReason.Reason_Description;

                    ctx.SaveChanges(); //saves changes to Database
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok("Saved Succesfully!");
        }
        //Delete cancel reason based on ID
          [HttpDelete]
         [Route("DeleteCancelReason")]
         public IHttpActionResult DeleteCancelReason(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid ID");
            }

            using (var ctx = new MediStock_DBEntities())
            {
                ctx.CallCancelReasons.Remove(ctx.CallCancelReasons.Single(z => z.Reason_ID == id));
                ctx.SaveChanges();
               
            }

            return Ok("Deleted Succesfully");
        }

    }


    
    


}
