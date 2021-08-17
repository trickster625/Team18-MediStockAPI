using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inventory
{
    public class VehicleInventoryController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getVehicleInventory")]
        public IHttpActionResult getVehicleInventory()
        {
            try
            {
                List<VehicleInventory> outputVehicleInventory = new List<VehicleInventory>();
                var storedInventory = db.VehicleInventories.ToList();

                foreach (var storedItem in storedInventory)
                {
                    VehicleInventory newVehicleInventory = new VehicleInventory();

                    newVehicleInventory.Vehicle_ID = storedItem.Vehicle_ID;
                    newVehicleInventory.Inventory_ID = storedItem.Inventory_ID;
                    newVehicleInventory.MaximumQty = storedItem.MaximumQty;
                    newVehicleInventory.MinimumQty = storedItem.MinimumQty;
                    newVehicleInventory.VehicleInventory_Qty = storedItem.VehicleInventory_Qty;

                    outputVehicleInventory.Add(newVehicleInventory);
                }

                return Ok(outputVehicleInventory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("addVehicleInventory")]
        public IHttpActionResult addVehicleInventory(VehicleInventory addedInventory)
        {
            try
            {

                var VehicleInventories = db.VehicleInventories.ToList();
                bool itemLoaded = false;

                foreach (var item in VehicleInventories)
                {

                    if (item.Inventory_ID == addedInventory.Inventory_ID && item.Vehicle_ID == addedInventory.Vehicle_ID)
                    {
                        itemLoaded = true;
                    }

                }

                if (itemLoaded == true)
                {
                    VehicleInventory currentVehicleInventory = new VehicleInventory();
                    currentVehicleInventory = db.VehicleInventories.Where(z => z.Inventory_ID == addedInventory.Inventory_ID && z.Vehicle_ID == addedInventory.Vehicle_ID).FirstOrDefault();
                    currentVehicleInventory.VehicleInventory_Qty = (currentVehicleInventory.VehicleInventory_Qty + addedInventory.VehicleInventory_Qty);
                }
                else
                {
                    db.VehicleInventories.Add(addedInventory);
                }

                Models.Inventory currentInventory = new Models.Inventory();
                currentInventory = db.Inventories.Where(z => z.Inventory_ID == addedInventory.Inventory_ID).FirstOrDefault();
                currentInventory.Inventory_BaseCampQty = (currentInventory.Inventory_BaseCampQty - addedInventory.VehicleInventory_Qty);

                db.SaveChangesAsync();

                return Ok("Vehicle Inventory Added");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("deleteVehicleInventory")]
        public IHttpActionResult deleteVehicleInventory(int vehicleID, int inventoryID)
        {
            try
            {
                VehicleInventory vehicleInventory = db.VehicleInventories.Single(z => z.Inventory_ID == inventoryID && z.Vehicle_ID == vehicleID);
             
                var inventoryItems = db.Inventories.ToList();

                foreach (var item in inventoryItems)
                {
                    if (item.Inventory_ID == inventoryID)
                    {
                        item.Inventory_BaseCampQty = (item.Inventory_BaseCampQty + vehicleInventory.VehicleInventory_Qty);
                    }
                }

                db.VehicleInventories.Remove(db.VehicleInventories.Single(z => z.Inventory_ID == inventoryID && z.Vehicle_ID == vehicleID));

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
