using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediStockAPI.Controllers.Call_SubSystem.ViewsControllers
{
    public class FullVehicleInventoryController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();


        //Get Method for FUll Calls View
        [HttpGet]
        [Route("GetFullVehicleInventory")]
        public IHttpActionResult GetVehicelInventory()
        {
            try
            {
                IList<FullVehicleInventory> calls = null;

                using (var ctx = new MediStock_DBEntities())
                {
                    calls = db.FullVehicleInventories.Select(s => new FullVehicleInventory()
                    {
                        Call_ID = s.Call_ID,
                        Vehicle_ID = s.Vehicle_ID,
                        MinimumQty = s.MinimumQty,
                        MaximumQty = s.MaximumQty,
                        VehicleInventory_Qty = s.VehicleInventory_Qty,
                        Inventory_Name = s.Inventory_Name,
                        Inventory_ID = s.Inventory_ID,
                        Employee_ID = s.Employee_ID


                    }).ToList<FullVehicleInventory>();
                }

                return Ok(calls);
            }
            catch (Exception)
            {

                return BadRequest("not working :-(");
            }
        }

            [HttpGet]
            [Route("SearchFullVehicleInventory")]

            public IEnumerable<FullVehicleInventory> GetCallID(int Search)
            {
                try
                {
                    return (IEnumerable<FullVehicleInventory>) db.FullVehicleInventories.Where(p => p.Call_ID == Search);

                }
                catch (Exception)
                {

                    throw;
                }

            }


        }
    }
}
