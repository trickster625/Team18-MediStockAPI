using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Supplier
{
    public class OrderController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getOrders")]
        public IHttpActionResult getOrders()
        {
            try
            {
                List<Order> outputOrders = new List<Order>();
                var storedOrders = db.Orders.ToList();

                foreach (var storedOrder in storedOrders)
                {
                    Order order = new Order();

                    order.Order_ID = storedOrder.Order_ID;
                    order.Supplier_ID = storedOrder.Supplier_ID;
                    order.OrderStatus_ID = storedOrder.OrderStatus_ID;
                    order.Order_Date = storedOrder.Order_Date;
                    order.Order_DateScanned = storedOrder.Order_DateScanned;

                    outputOrders.Add(order);
                }

                outputOrders = outputOrders.OrderBy(z => z.Order_Date).ToList();
                return Ok(outputOrders);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("createOrder")]
        public IHttpActionResult createOrder(Order newOrder)
        {
            try
            {
                db.Orders.Add(newOrder);
                db.SaveChangesAsync();

                return Ok("Order Added");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

       

    }
}
