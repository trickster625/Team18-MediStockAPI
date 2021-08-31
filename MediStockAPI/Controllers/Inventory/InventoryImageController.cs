using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inventory
{
    public class InventoryImageController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        public int selectedItemID = 0;

        [HttpGet]
        [Route("getLatestItem")]
        public IHttpActionResult getLatestItem()
        {
            try
            {
                var latestItemID = db.Inventories.OrderByDescending(z => z.Inventory_ID).FirstOrDefault().Inventory_ID;

                selectedItemID = latestItemID;

                return Ok(latestItemID);
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

        [HttpPost]
        [Route("createInventoryImage")]
        public IHttpActionResult createInventoryImage()
        {
            try
            {
                var path = "";
                var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                        path = Path.Combine(
                        HttpContext.Current.Server.MapPath("~/Images/"),
                        fileName
                    );

                    file.SaveAs(path);
                }

                getLatestItem();

                var itemID = selectedItemID;

                Models.Inventory currentItem = new Models.Inventory();
                currentItem = db.Inventories.Where(z => z.Inventory_ID == itemID).FirstOrDefault();

                currentItem.Inventory_Picture = path;

                db.SaveChangesAsync();

                return Ok("Photo Added");
            }
            catch (Exception err)
            {
                return BadRequest((err).ToString());
            }
        }

    }
}
