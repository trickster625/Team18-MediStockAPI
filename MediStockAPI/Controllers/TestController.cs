using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers
{
    public class TestController : ApiController
    {

        //    MedistockInventoryTestEntities db = new MedistockInventoryTestEntities();

        //    [HttpGet]
        //    [Route("GetCurrentItem")]
        //    public IHttpActionResult getCurrentItem(int id)
        //    {

        //        try
        //        {
        //            var items = db.Inventories.ToList();
        //            List<InventoryVM> ItemList = new List<InventoryVM>();
        //            InventoryVM currentItem = new InventoryVM();

        //            foreach (var item in items)
        //            {

        //                if (item.InventoryID == id)
        //                {
        //                    currentItem.InventoryID = id;
        //                    currentItem.InventoryName = item.InventoryName;
        //                    currentItem.InventoryTypeID = item.TypeID;
        //                    return Ok(currentItem);
        //                }

        //            }

        //            return Ok("No Match Found");
        //        }
        //        catch (Exception)
        //        {
        //            return BadRequest();
        //        }

        //    }
        //}

    }

}
