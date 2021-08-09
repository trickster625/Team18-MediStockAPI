using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers
{
    public class WriteOffReasonsController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getReasons")]
        public IHttpActionResult getReasons()
        {
            try
            {
                List<Write_OffReason> outputReasons = new List<Write_OffReason>();
                var storedReasons = db.Write_OffReason.ToList();

                foreach (var storedReason in storedReasons)
                {
                    Write_OffReason reason = new Write_OffReason();
                    reason.Write_OffReason_Description = storedReason.Write_OffReason_Description;
                    reason.Write_OffReason_ID = storedReason.Write_OffReason_ID;
                    outputReasons.Add(reason);
                }

                return Ok(outputReasons);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("createReason")]
        public IHttpActionResult createReason(Write_OffReason newReason)
        {
            try
            {
                db.Write_OffReason.Add(newReason);
                db.SaveChangesAsync();

                return Ok("Reason Added");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("updateReason")]
        public IHttpActionResult updateReason(Write_OffReason updateReason)
        {
            try
            {
                Write_OffReason currentReason = new Write_OffReason();
                currentReason = db.Write_OffReason.Where(z => z.Write_OffReason_ID == updateReason.Write_OffReason_ID).FirstOrDefault();

                currentReason.Write_OffReason_Description = updateReason.Write_OffReason_Description;
                db.SaveChangesAsync();

                return Ok("Reason Updated!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("deleteReason")]
        public IHttpActionResult deleteReason(int id)
        {
            try
            {
                db.Write_OffReason.Remove(db.Write_OffReason.Single(z => z.Write_OffReason_ID == id));

                db.SaveChangesAsync();

                return Ok("Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
