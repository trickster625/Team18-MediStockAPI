using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;
using MediStockAPI.Models.ReceiveOrderVM;

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

                outputOrders = outputOrders.AsEnumerable().OrderBy(z=>z.Order_Date).GroupBy(x=>x.OrderStatus_ID).SelectMany(g=>g).ToList();
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

       [HttpPut]
       [Route("receiveOrder")]
        public IHttpActionResult receiveOrder(ReceiveOrderVM[] receivedOrder)
        {
            try
            {

                var receivedOrderID = receivedOrder[0].Order_ID;
                Order currentOrder = new Order();

                currentOrder = db.Orders.Where(x => x.Order_ID == receivedOrderID).FirstOrDefault();
                currentOrder.OrderStatus_ID = 2;
                currentOrder.Order_DateScanned = DateTime.Now;

                for (int i = 0; i < receivedOrder.Length; i++)
                {
                    var receivedInventoryID = receivedOrder[i].Inventory_ID;
                    var receivedQuantity = receivedOrder[i].Inventory_QtyReceived;

                    Models.Inventory currentItem = new Models.Inventory();
                    currentItem = db.Inventories.Where(z => z.Inventory_ID == receivedInventoryID).FirstOrDefault();

                    currentItem.Inventory_BaseCampQty = (currentItem.Inventory_BaseCampQty + receivedQuantity);
                }

                db.SaveChangesAsync();
                return Ok("Order Received!");
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }
    }
}
