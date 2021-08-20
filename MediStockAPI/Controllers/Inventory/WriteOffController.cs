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

        [HttpGet]
        [Route("getWriteOffs")]
        public IHttpActionResult getWriteOffs()
        {
            try
            {
                List<Written_OffInventory> outputWriteOff = new List<Written_OffInventory>();
                var storedWriteOffs = db.Written_OffInventory.ToList();

                foreach (var storedWriteOff in storedWriteOffs)
                {
                    Written_OffInventory writeOff = new Written_OffInventory();

                    writeOff.Write_Off_ID = storedWriteOff.Write_Off_ID;
                    writeOff.Write_OffReason_ID = storedWriteOff.Write_OffReason_ID;
                    writeOff.Inventory_ID = storedWriteOff.Inventory_ID;
                    writeOff.Write_Off_Qty = storedWriteOff.Write_Off_Qty;
                    writeOff.Write_Off_Date = storedWriteOff.Write_Off_Date;
                    writeOff.Employee_ID = storedWriteOff.Employee_ID;

                    outputWriteOff.Add(writeOff);
                }

                return Ok(outputWriteOff);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

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
