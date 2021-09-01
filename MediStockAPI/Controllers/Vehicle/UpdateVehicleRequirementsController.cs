using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Vehicle
{
    public class UpdateVehicleRequirementsController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpPut]
        [Route("updateVehicleReq")]
        public IHttpActionResult updateVehicleReq(VehicleInventory updatedVehicleReq)
        {
            try
            {
                Models.VehicleInventory currentVehicle = new Models.VehicleInventory();
                currentVehicle = db.VehicleInventories.Where(z => z.Vehicle_ID == updatedVehicleReq.Vehicle_ID).FirstOrDefault();

                currentVehicle.MinimumQty = updatedVehicleReq.MinimumQty;
                currentVehicle.MaximumQty = updatedVehicleReq.MaximumQty;

                db.SaveChangesAsync();

                return Ok("Vehicle Requirements Updated!");
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }
    }
}
