using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Supplier
{
    public class OrderSecondController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getLatestOrder")]
        public IHttpActionResult getLatestOrder()
        {
            try
            {
                var latestOrderID = db.Orders.OrderByDescending(z => z.Order_ID).FirstOrDefault().Order_ID;

                return Ok(latestOrderID);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
