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

        MediStock_DBEntities db = new MediStock_DBEntities();

        //[HttpGet]
        //[Route("GetItemTypes")]
        //public IHttpActionResult getItemTypes()
        //{
        //    try
        //    {
        //        var types = db.InventoryTypes.ToList();
        //        List<InventoryType> typeList = new List<InventoryType>();

        //        foreach (var item in types)
        //        {

        //            InventoryType newInventoryType = new InventoryType();

        //            newInventoryType.InventoryType_ID = item.InventoryType_ID;
        //            newInventoryType.InventoryType_Description = item.InventoryType_Description;

        //            typeList.Add(newInventoryType);

        //        }

        //        return Ok(typeList);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}


        //    MedistockInventoryTestEntities db = new MedistockInventoryTestEntities();

        //    [HttpGet]
        //    [Route("GetAllItems")]
        //    public IHttpActionResult getItems()
        //    {

        //        try
        //        {
        //            var items = db.Inventories.ToList();
        //            var types = db.InventoryTypes.ToList();
        //            List<InventoryVM> ItemList = new List<InventoryVM>();

        //            foreach (var item in items)
        //            {

        //                InventoryVM invItem = new InventoryVM();

        //                invItem.InventoryID = item.InventoryID;
        //                invItem.InventoryName = item.InventoryName;
        //                invItem.InventoryTypeID = item.TypeID;

        //                foreach (var type in types)
        //                {
        //                    if (item.TypeID == type.TypeID)
        //                    {
        //                        invItem.InventoryType = type.TypeDescription;
        //                    }
        //                }

        //                ItemList.Add(invItem);

        //            }

        //            return Ok(ItemList);

        //        }
        //        catch (Exception)
        //        {
        //            return BadRequest();
        //        }

        //    }

        [HttpPost]
        [Route("CreateItem")]
        public IHttpActionResult createIem(Inventory inventoryItem)
        {

            try
            {
                db.Inventories.Add(inventoryItem);
                db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        //    [HttpDelete]
        //    [Route("DeleteItem")]
        //    public IHttpActionResult deleteItem(int id)
        //    {
        //        try
        //        {
        //            db.Inventories.Remove(db.Inventories.Single(z => z.InventoryID == id));

        //            db.SaveChangesAsync();

        //            return Ok("Deleted");
        //        }
        //        catch (Exception)
        //        {
        //            return BadRequest();
        //        }
        //    }

        //    [HttpPut]
        //    [Route("UpdateItem")]
        //    public IHttpActionResult updateItem(Inventory updatedItem)

        //    {
        //        try
        //        {
        //            Inventory currentItem = new Inventory();
        //            currentItem = db.Inventories.Where(z => z.InventoryID == updatedItem.InventoryID).FirstOrDefault();


        //            currentItem.InventoryName = updatedItem.InventoryName;
        //            currentItem.TypeID = updatedItem.TypeID;

        //            db.SaveChangesAsync();

        //            return Ok("Updated");
        //        }
        //        catch (Exception)
        //        {
        //            return BadRequest();
        //        }
        //    }

        //}

    }
}
