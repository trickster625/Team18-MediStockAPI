using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers
{   
    /*
    public class InventoryTypeController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("getInventoryTypes")]
        public IHttpActionResult getInventoryTypes()
        {
            try
            {
                List<InventoryType> outputTypes = new List<InventoryType>();
                var storedTypes = db.InventoryTypes.ToList();

                foreach (var storedType in storedTypes)
                {
                    InventoryType type = new InventoryType();
                    type.InventoryType_ID = storedType.InventoryType_ID;
                    type.InventoryType_Description = storedType.InventoryType_Description;
                    outputTypes.Add(type);
                }

                return Ok(outputTypes);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    } */
}
