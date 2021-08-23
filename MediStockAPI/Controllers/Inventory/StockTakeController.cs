using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inventory
{
    public class StockTakeController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getLatestStocktake")]
        public IHttpActionResult getLatestStocktake()
        {
            try
            {
                var latestStockTakeID = db.StockTakes.OrderByDescending(z => z.StockTake_ID).FirstOrDefault().StockTake_ID;

                return Ok(latestStockTakeID);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("createStockTake")]
        public IHttpActionResult createStockTake(StockTake newStocktake) 
        {
            try
            {
                db.StockTakes.Add(newStocktake);
                db.SaveChangesAsync();
                return Ok("Stocktake Added!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
