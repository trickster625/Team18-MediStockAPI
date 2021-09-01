using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inspections
{
    public class ChecklistItemTypeController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getChecklistItemTypes")]
        public IHttpActionResult getChecklistItemTypes()
        {
            try
            {
                List<ChecklistItemType> outputTypes = new List<ChecklistItemType>();
                var storedTypes = db.ChecklistItemTypes.ToList();

                foreach (var storedType in storedTypes)
                {
                    ChecklistItemType type = new ChecklistItemType();

                    type.ChecklistItemType_ID = storedType.ChecklistItemType_ID;
                    type.ChecklistItemType_Description = storedType.ChecklistItemType_Description;

                    outputTypes.Add(type);
                }

                outputTypes = outputTypes.OrderBy(z => z.ChecklistItemType_Description).ToList();
                return Ok(outputTypes);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
