using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inventory
{
    public class InventoryCategoryController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getInventoryCategories")]
        public IHttpActionResult getInventoryCategories()
        {
            try
            {
                List<InventoryCategory> outputCategories = new List<InventoryCategory>();
                var storedCategories = db.InventoryCategories.ToList();

                foreach (var storedCategory in storedCategories)
                {
                    InventoryCategory category = new InventoryCategory();

                    category.InventoryCategory_ID = storedCategory.InventoryCategory_ID;
                    category.InventoryCategory_Description = storedCategory.InventoryCategory_Description;

                    outputCategories.Add(category);
                }

                return Ok(outputCategories);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
