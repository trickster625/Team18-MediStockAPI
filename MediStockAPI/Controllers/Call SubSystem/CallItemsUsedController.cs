using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Call_SubSystem
{
    public class CallItemsUsedController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();
        
        [HttpGet]
        [Route("GetAllItemsUsed")]

        //Get to find all cancel reasons
        public IHttpActionResult GetAllItemsUsed()
        {
            IList<CallItemsUsedVM> items= null;
            using (var ctx = new MediStock_DBEntities())
            {
                items = ctx.Call_ItemsUsed.Select(s => new CallItemsUsedVM()
                {
                    ItemsUsed_ID = s.ItemsUsed_ID,
                    Call_ID = s.Call_ID,
                    Inventory_ID = s.Inventory_ID,
                    ItemsUsed_Qty = (int)s.ItemsUsed_Qty
                }).ToList<CallItemsUsedVM>();
            }
            if (items.Count == 0)
            {
                return NotFound();
            }
            return Ok(items);
        }

        [HttpPost]
        [Route("CreateItemsUsed")]
        public async Task<IHttpActionResult> AddNewItem(Call_ItemsUsed call_ItemsUsed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid Data.");
            }

            using (var ctx = new MediStock_DBEntities())
            {
                ctx.Call_ItemsUsed.Add(call_ItemsUsed);
                await ctx.SaveChangesAsync();
            }
            return Ok();
        }


        //Updating Call Items used
        [HttpPut]
        [Route("UpdateCallItemsUsed")]
        public IHttpActionResult Put(Call_ItemsUsed call_ItemsUsed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid call Reason.");
            }

            using (var ctx = new MediStock_DBEntities())
            {
                //Searches for Reason and sets it equal to variable using LINQ
                var existingItem = ctx.Call_ItemsUsed.Where(s => s.ItemsUsed_ID == call_ItemsUsed.ItemsUsed_ID).FirstOrDefault<Call_ItemsUsed>();

                if (existingItem != null)
                {
                    existingItem.ItemsUsed_ID = call_ItemsUsed.ItemsUsed_ID ;
                    existingItem.Call_ID = call_ItemsUsed.Call_ID;
                    existingItem.Inventory_ID = call_ItemsUsed.Inventory_ID;
                    existingItem.ItemsUsed_Qty = call_ItemsUsed.ItemsUsed_Qty;

                    ctx.SaveChanges(); //saves changes to Database
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        //Delete cancel reason based on ID
        [HttpDelete]
        [Route("DeleteCallItemUsed")]
        public IHttpActionResult DeleteCancelReason(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid ID");
            }

            using (var ctx = new MediStock_DBEntities())
            {
                ctx.Call_ItemsUsed.Remove(ctx.Call_ItemsUsed.Single(z => z.ItemsUsed_ID == id));
                ctx.SaveChanges();

            }

            return Ok("Deleted Succesfully");
        }


    }
}
