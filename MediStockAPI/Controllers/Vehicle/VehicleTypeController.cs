using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers
{
    public class VehicleTypeController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getVehicleTypes")]
        public IHttpActionResult getVehicleTypes()
        {
            try
            {
                List<VehicleType> outputTypes = new List<VehicleType>();
                var storedTypes = db.VehicleTypes.ToList();

                foreach (var storedType in storedTypes)
                {
                    VehicleType type = new VehicleType();
                    type.VehicleType_ID = storedType.VehicleType_ID;
                    type.VehicleType_Description = storedType.VehicleType_Description;
                    outputTypes.Add(type);
                }

                return Ok(outputTypes);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
