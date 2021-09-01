using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inspections
{
    public class ChecklistReportController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getChecklistsReport")]
        public IHttpActionResult getChecklistsReport()
        {
            try
            {
                List<Checklist> outputChecklists = new List<Checklist>();
                var storedChecklists = db.Checklists.ToList();

                foreach (var storedChecklist in storedChecklists)
                {
                    Checklist checkilist = new Checklist();

                    checkilist.Checklist_ID = storedChecklist.Checklist_ID;
                    checkilist.Checklist_Name = storedChecklist.Checklist_Name;

                    outputChecklists.Add(checkilist);
                }

                outputChecklists = outputChecklists.OrderBy(z => z.Checklist_Name).ToList();
                return Ok(outputChecklists);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
