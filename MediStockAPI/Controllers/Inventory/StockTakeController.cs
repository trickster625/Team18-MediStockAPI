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
        [Route("getStockTakes")]
        public IHttpActionResult getStockTakes()
        {
            try
            {
                List<StockTake> outputStockTakes = new List<StockTake>();
                var storedStockTakes = db.StockTakes.ToList();

                foreach (var storedStockTake in storedStockTakes)
                {
                    StockTake stockTake = new StockTake();

                    stockTake.Employee_ID = storedStockTake.Employee_ID;
                    stockTake.StockTake_DateTime = storedStockTake.StockTake_DateTime;

                    outputStockTakes.Add(stockTake);
                }

                outputStockTakes = outputStockTakes.OrderBy(z => z.StockTake_DateTime).ToList();
                return Ok(outputStockTakes);
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
