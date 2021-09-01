using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inspection
{
    public class ChecklistController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getChecklists")]

        public IHttpActionResult getChecklists()
        {
            try
            {
                List<ChecklistVM> outputChecklists = new List<ChecklistVM>();

                var storedChecklists = db.Checklists.ToList();
                
                foreach (var storedChecklist in storedChecklists)
                {
                    ChecklistVM checklist = new ChecklistVM();

                    checklist.Checklist_ID = storedChecklist.Checklist_ID;
                    checklist.Checklist_Name = storedChecklist.Checklist_Name;



                    outputChecklists.Add(checklist);
                }

                return Ok(outputChecklists);

            }

            catch (Exception err)
            {

                return BadRequest((err).ToString());
            }
        }

        [HttpGet]
        [Route("getFilteredChecklists")]
        public IHttpActionResult getFilteredChecklists(string searchName)
        {

            try
            {
                var checklists = db.Checklists.ToList();
                List<ChecklistVM> ChecklistList = new List<ChecklistVM>();

                foreach (var checklist in checklists)
                {

                    if (checklist.Checklist_Name == searchName)
                    {
                        ChecklistVM checklistItem = new ChecklistVM();

                        checklistItem.Checklist_ID = checklist.Checklist_ID;
                        checklistItem.Checklist_Name = checklist.Checklist_Name;

                        ChecklistList.Add(checklistItem);
                    }

                }

                return Ok(ChecklistList);
            }

            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

        [HttpGet]
        [Route("getCurrentChecklist")]
        public IHttpActionResult getCurrentChecklist(int id)
        {

            try
            {
                var checklists = db.Checklists.ToList();
                List<ChecklistVM> ChecklistList = new List<ChecklistVM>();
                ChecklistVM currentChecklist = new ChecklistVM();

                foreach (var checklist in checklists)
                {

                    if (checklist.Checklist_ID == id)
                    {
                        currentChecklist.Checklist_ID = id;
                        currentChecklist.Checklist_Name = checklist.Checklist_Name;
                        return Ok(currentChecklist);
                    }

                }

                return Ok("No Match Found");
            }

            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }

        }

        [HttpPost]
        [Route("createChecklist")]
        public IHttpActionResult createChecklist(Models.Checklist newChecklist)
        {
            try
            {
                db.Checklists.Add(newChecklist);
                db.SaveChangesAsync();

                return Ok("Checklist Added!");
            }

            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

        [HttpPut]
        [Route("updateChecklist")]
        public IHttpActionResult updateChecklist(Models.Checklist updateChecklist)
        {
            try
            {
                Models.Checklist currentChecklist = new Models.Checklist();
                currentChecklist = db.Checklists.Where(z => z.Checklist_ID == updateChecklist.Checklist_ID).FirstOrDefault();

                currentChecklist.Checklist_ID = updateChecklist.Checklist_ID;
                currentChecklist.Checklist_Name = updateChecklist.Checklist_Name;

                db.SaveChangesAsync();

                return Ok("Checklist Updated!");
            }

            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

        [HttpDelete]
        [Route("deleteChecklist")]
        public IHttpActionResult deleteChecklist(int id)
        {
            try
            {
                db.Checklists.Remove(db.Checklists.Single(z => z.Checklist_ID == id));

                db.SaveChangesAsync();

                return Ok("Checklist Deleted!");
            }

            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }
    }
}
