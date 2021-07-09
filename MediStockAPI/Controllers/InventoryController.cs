using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers
{
    public class InventoryController : ApiController
    {

        // FRANCO API TEST 
        // Recoding as well

        MediStockTestEntities db = new MediStockTestEntities();

        public IHttpActionResult GetAllItems()
        {

            try
            {
                var items = db.Inventories.ToList();

                return Ok(items);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        //Johan was here

    }
}
