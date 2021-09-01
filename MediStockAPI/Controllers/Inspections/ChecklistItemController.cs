using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inspections
{
    public class ChecklistItemController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getChecklistItems")]
        public IHttpActionResult getChecklistItems()
        {
            try
            {
                List<ChecklistItem> outputItems = new List<ChecklistItem>();
                var storedItems = db.ChecklistItems.ToList();

                foreach (var storedItem in storedItems)
                {
                    ChecklistItem item = new ChecklistItem();

                    item.ChecklistItem_ID = storedItem.ChecklistItem_ID;
                    item.ChecklistItem_Description = storedItem.ChecklistItem_Description;
                    item.ChecklistItem_ComplianceValue = storedItem.ChecklistItem_ComplianceValue;
                    item.ChecklistItemType_ID = storedItem.ChecklistItemType_ID;

                    outputItems.Add(item);
                }

                outputItems = outputItems.OrderBy(z => z.ChecklistItem_Description).ToList();
                return Ok(outputItems);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

        [HttpPost]
        [Route("createChecklistItem")]
        public IHttpActionResult createChecklistItem(ChecklistItem newItem)
        {
            try
            {
                db.ChecklistItems.Add(newItem);
                db.SaveChangesAsync();

                return Ok("Checklist Item Added");
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

        [HttpPut]
        [Route("updateChecklistItem")]
        public IHttpActionResult updateChecklistItem(ChecklistItem updateItem)
        {
            try
            {
                ChecklistItem currentItem = new ChecklistItem();
                currentItem = db.ChecklistItems.Where(z => z.ChecklistItem_ID == updateItem.ChecklistItem_ID).FirstOrDefault();

                currentItem.ChecklistItem_Description = updateItem.ChecklistItem_Description;
                currentItem.ChecklistItemType_ID = updateItem.ChecklistItemType_ID;

                db.SaveChangesAsync();

                return Ok("Checklist Item Updated!");
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

        [HttpDelete]
        [Route("deleteChecklistItem")]
        public IHttpActionResult deleteChecklistItem(int id)
        {
            try
            {
                db.ChecklistItems.Remove(db.ChecklistItems.Single(z => z.ChecklistItem_ID == id));

                db.SaveChangesAsync();

                return Ok("Deleted");
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
