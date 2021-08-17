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

        [HttpPost]
        [Route("createStockTake")]
        public IHttpActionResult createStockTake(FullStockTakeVM[] newStocktake) 
        {
            try
            {

                StockTake newStockTakeItem = new StockTake();

                newStockTakeItem.Employee_ID = newStocktake[1].Employee_ID;
                newStockTakeItem.StockTake_DateTime = newStocktake[1].StockTake_DateTime;

                db.StockTakes.Add(newStockTakeItem);

                db.SaveChangesAsync();

                StockTake latestStockTake = new StockTake();

                latestStockTake = db.StockTakes.LastOrDefault();

                for (int i = 0; i < newStocktake.Length; i++)
                {
                    StockTakeTotal newStockTakeTotal = new StockTakeTotal();

                    newStockTakeTotal.Inventory_ID = newStocktake[i].Inventory_ID;
                    newStockTakeTotal.StockTake_ID = latestStockTake.StockTake_ID;
                    newStockTakeTotal.StockTakeTotal_Qty = newStocktake[i].StockTakeTotal_Qty;

                    db.StockTakeTotals.Add(newStockTakeTotal);
                }

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
