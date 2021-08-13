using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inventory
{
    public class WriteOffController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpPost]
        [Route("createWriteOff")]
        public IHttpActionResult createWriteOff(Written_OffInventory writeOff)
        {
            try
            {
                Models.Inventory currentItem = new Models.Inventory();
                currentItem = db.Inventories.Where(z => z.Inventory_ID == writeOff.Inventory_ID).FirstOrDefault();
                currentItem.Inventory_BaseCampQty = (currentItem.Inventory_BaseCampQty - writeOff.Write_Off_Qty);

                db.Written_OffInventory.Add(writeOff);

                db.SaveChangesAsync();

                return Ok("WriteOff Added");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
