using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Supplier
{
    public class OrderStatusController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getOrderStatus")]
        public IHttpActionResult getOrderStatus()
        {
            try
            {
                List<OrderStatu> outputStatusses = new List<OrderStatu>();
                var storedStatusses = db.OrderStatus.ToList();

                foreach (var storedStatus in storedStatusses)
                {
                    OrderStatu status = new OrderStatu();

                    status.OrderStatus_ID = storedStatus.OrderStatus_ID;
                    status.OrderStatus_Description = storedStatus.OrderStatus_Description;

                    outputStatusses.Add(status);
                }

                return Ok(outputStatusses);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
