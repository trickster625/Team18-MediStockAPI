using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Models.ReportingVM
{
    public class StockPriceChangeReportController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getPriceChange")]
        public IHttpActionResult getPriceChange(int ItemID)
        {
            try
            {
                List<PriceHistory> outputPriceHistory = new List<PriceHistory>();
                var storedPriceHistories = db.PriceHistories.Where(z=>z.Inventory_ID == ItemID).ToList();

                foreach (var storedPriceHistory in storedPriceHistories)
                {
                    PriceHistory price = new PriceHistory();

                    price.Inventory_ID = storedPriceHistory.Inventory_ID;
                    price.PriceHistory_Date = storedPriceHistory.PriceHistory_Date;
                    price.PriceHistory_Price = storedPriceHistory.PriceHistory_Price;

                    outputPriceHistory.Add(price);
                }

                return Ok(outputPriceHistory);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
