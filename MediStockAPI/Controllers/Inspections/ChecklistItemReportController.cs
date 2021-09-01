using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inspections
{
    public class ChecklistItemReportController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getChecklistItemsReport")]
        public IHttpActionResult getChecklistItemsReport()
        {
            try
            {
                List<ChecklistItem> outputChecklistItems = new List<ChecklistItem>();
                var storedItems = db.ChecklistItems.ToList();

                foreach (var storedItem in storedItems)
                {
                    ChecklistItem checkilistItem = new ChecklistItem();

                    checkilistItem.ChecklistItem_ID = storedItem.ChecklistItem_ID;
                    checkilistItem.ChecklistItem_Description = storedItem.ChecklistItem_Description;

                    outputChecklistItems.Add(checkilistItem);
                }

                outputChecklistItems = outputChecklistItems.OrderBy(z => z.ChecklistItem_Description).ToList();
                return Ok(outputChecklistItems);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
