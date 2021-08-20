using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inventory
{
    public class InventoryController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getInventoryItems")]
        public IHttpActionResult getInventoryItems()
        {
            try
            {
                List<InventoryFullVM> outputItems = new List<InventoryFullVM>();

                List<int> barcodeIDs = new List<int>();
                List<string> barcodeNumbers = new List<string>();

                var storedItems = db.Inventories.ToList();
                var storedCategories = db.InventoryCategories.ToList();
                var storedBarcodes = db.Barcodes.ToList();

                foreach (var storedItem in storedItems)
                {
                    barcodeIDs.Clear();
                    barcodeNumbers.Clear();

                    InventoryFullVM item = new InventoryFullVM();

                    item.Inventory_ID = storedItem.Inventory_ID;
                    item.InventoryCategory_ID = storedItem.InventoryCategory_ID;
                    item.Inventory_Name = storedItem.Inventory_Name;
                    item.Inventory_LatestPrice = (decimal)storedItem.Inventory_LatestPrice;
                    item.Inventory_BaseCampQty = (int)storedItem.Inventory_BaseCampQty;

                    foreach (var storedCategory in storedCategories)
                    {
                        if (storedItem.InventoryCategory_ID == storedCategory.InventoryCategory_ID)
                        {
                            item.InventoryCategory_Description = storedCategory.InventoryCategory_Description;
                        }
                    }

                    foreach (var storedBarcode in storedBarcodes)
                    {
                        if (storedBarcode.Inventory_ID == storedItem.Inventory_ID)
                        {
                            barcodeIDs.Add(storedBarcode.Barcode_ID);
                            barcodeNumbers.Add(storedBarcode.Barcode_Number);
                        }
                    }

                    int[] idArray = barcodeIDs.ToArray();
                    string[] numberArray = barcodeNumbers.ToArray();

                    item.Barcode_ID = idArray;
                    item.BarcodeNumber = numberArray;

                    outputItems.Add(item);
                }

                outputItems = outputItems.OrderBy(z => z.Inventory_Name).ToList();
                return Ok(outputItems);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("createItem")]
        public IHttpActionResult createItem(Models.Inventory newInventoryItem)
        {
            try
            {
                db.Inventories.Add(newInventoryItem);
                db.SaveChangesAsync();

                return Ok("Item Added");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("updateItem")]
        public IHttpActionResult updateItem(Models.Inventory updateItem)
        {
            try
            {
                Models.Inventory currentItem = new Models.Inventory();
                currentItem = db.Inventories.Where(z => z.Inventory_ID == updateItem.Inventory_ID).FirstOrDefault();

                currentItem.InventoryCategory_ID = updateItem.InventoryCategory_ID;
                currentItem.Inventory_Name = updateItem.Inventory_Name;
                currentItem.Inventory_LatestPrice = updateItem.Inventory_LatestPrice;

                db.SaveChangesAsync();

                return Ok("Reason Updated!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("deleteItem")]
        public IHttpActionResult deleteItem(int id)
        {
            try
            {
                db.Inventories.Remove(db.Inventories.Single(z => z.Inventory_ID == id));

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
