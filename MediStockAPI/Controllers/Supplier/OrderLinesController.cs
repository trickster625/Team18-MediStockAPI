using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Supplier
{
    public class OrderLinesController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getOrderLines")]
        public IHttpActionResult getOrderLines()
        {
            try
            {
                List<OrderLine> outputOrderLines = new List<OrderLine>();
                var storedOrderLines = db.OrderLines.ToList();

                foreach (var storedOrderLine in storedOrderLines)
                {
                    OrderLine orderLine = new OrderLine();

                    orderLine.Order_ID = storedOrderLine.Order_ID;
                    orderLine.Inventory_ID = storedOrderLine.Inventory_ID;
                    orderLine.OrderLine_Quantity = storedOrderLine.OrderLine_Quantity;

                    outputOrderLines.Add(orderLine);
                }

                return Ok(outputOrderLines);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("createOrderLines")]
        public IHttpActionResult createOrderLines(OrderLine[] newOrderLine)
        {
            try
            {

                for (int i = 0; i < newOrderLine.Length; i++)
                {
                    db.OrderLines.Add(newOrderLine[i]);
                }

                db.SaveChangesAsync();

                return Ok("OrderLines Added");
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
