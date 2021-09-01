using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;
using MediStockAPI.Models.ReportingVM;

namespace MediStockAPI.Controllers.Reporting
{
    public class InspectionReportController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getInspectionChecklistReport")]
        public IHttpActionResult getInspectionChecklistReport()
        {
            try
            {
                List<InspectionReportVM> outputItems = new List<InspectionReportVM>();
                var storedItems = db.InspectionChecklists.ToList();
                var storedChecklists = db.Checklists.ToList();
                var storedChecklistItems = db.ChecklistItems.ToList();

                foreach (var storedItem in storedItems)
                {
                    InspectionReportVM item = new InspectionReportVM();

                    item.Checklist_ID = storedItem.Checklist_ID;
                    item.ChecklistItem_ID = storedItem.ChecklistItem_ID;
                    item.Passed = (bool)storedItem.Passed;

                    foreach (var storedChecklist in storedChecklists)
                    {
                        if (item.Checklist_ID == storedChecklist.Checklist_ID)
                        {
                            item.Checklist_Name = storedChecklist.Checklist_Name;
                        }
                    }

                    foreach (var storedChecklistItem in storedChecklistItems)
                    {
                        if (item.ChecklistItem_ID == storedChecklistItem.ChecklistItem_ID)
                        {
                            item.ChecklistItem_Description = storedChecklistItem.ChecklistItem_Description;
                        }
                    }

                    outputItems.Add(item);
                }

                return Ok(outputItems);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
