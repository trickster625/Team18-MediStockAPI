using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers
{
    public class FilterItemsController : ApiController
    {

        //    MedistockInventoryTestEntities db = new MedistockInventoryTestEntities();

        //    [HttpGet]
        //    [Route("GetFilteredItems")]
        //    public IHttpActionResult getFilteredItems(string searchName, int searchTypeID)
        //    {

        //        try
        //        {
        //            var items = db.Inventories.ToList();
        //            var types = db.InventoryTypes.ToList();
        //            List<InventoryVM> ItemList = new List<InventoryVM>();

        //            foreach (var item in items)
        //            {

        //                if (item.InventoryName==searchName && item.TypeID==searchTypeID)
        //                {
        //                    InventoryVM invItem = new InventoryVM();

        //                    invItem.InventoryID = item.InventoryID;
        //                    invItem.InventoryName = item.InventoryName;
        //                    invItem.InventoryTypeID = item.TypeID;

        //                    foreach (var type in types)
        //                    {
        //                        if (item.TypeID == type.TypeID)
        //                        {
        //                            invItem.InventoryType = type.TypeDescription;
        //                        }
        //                    }

        //                    ItemList.Add(invItem);
        //                }

        //            }

        //            return Ok(ItemList);
        //        }
        //        catch (Exception)
        //        {
        //            return BadRequest();
        //        }

        //    }
        //}

    }

}

