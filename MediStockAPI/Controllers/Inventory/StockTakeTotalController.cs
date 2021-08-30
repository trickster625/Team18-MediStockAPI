using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inventory
{
    public class StockTakeTotalController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getStockTakeTotals")]
        public IHttpActionResult getStockTakeTotals()
        {
            try
            {
                List<StockTakeTotal> outputStockTakeTotals = new List<StockTakeTotal>();
                var storedStockTakeTotals = db.StockTakeTotals.ToList();

                foreach (var storedStockTakeTotal in storedStockTakeTotals)
                {
                    StockTakeTotal total = new StockTakeTotal();

                    total.Inventory_ID = storedStockTakeTotal.Inventory_ID;
                    total.StockTake_ID = storedStockTakeTotal.StockTake_ID;
                    total.StockTakeTotal_Qty = storedStockTakeTotal.StockTakeTotal_Qty;

                    outputStockTakeTotals.Add(total);
                }

                return Ok(outputStockTakeTotals);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

        [HttpPost]
        [Route("createStockTakeTotal")]
        public IHttpActionResult createStockTakeTotal(StockTakeTotal[] newStocktakeTotal)
        {
            try
            {

                for (int i = 0; i < newStocktakeTotal.Length; i++)
                {
                    db.StockTakeTotals.Add(newStocktakeTotal[i]);

                    var newQuantity = newStocktakeTotal[i].StockTakeTotal_Qty;
                    var currentItemID = newStocktakeTotal[i].Inventory_ID;

                    Models.Inventory currentItem = new Models.Inventory();

                    currentItem = db.Inventories.Where(z => z.Inventory_ID == currentItemID).FirstOrDefault();
                    currentItem.Inventory_BaseCampQty = newQuantity;
                }

                db.SaveChangesAsync();
                return Ok("StocktakeTotals Added!");
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

        [HttpPut]
        [Route("UpdateStockTakeTotal")]
        public IHttpActionResult UpdateStockTakeTotal(StockTakeTotal[] newStocktakeTotal)
        {
            try
            {

                for (int i = 0; i < newStocktakeTotal.Length; i++)
                {
                    var newQuantity = newStocktakeTotal[i].StockTakeTotal_Qty;
                    var currentItemID = newStocktakeTotal[i].Inventory_ID;
                    Models.Inventory currentItem = new Models.Inventory();
                    currentItem = db.Inventories.Where(z => z.Inventory_ID == currentItemID).FirstOrDefault();
                    currentItem.Inventory_BaseCampQty = newQuantity;
                }

                db.SaveChangesAsync();

                return Ok("StocktakeTotals Updated!");
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
