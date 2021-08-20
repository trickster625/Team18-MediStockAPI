using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inventory
{
    public class BarcodeController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getBarcodes")]
        public IHttpActionResult getBarcodes()
        {
            try
            {
                List<Barcode> outputBarcode = new List<Barcode>();
                var storedBarcodes = db.Barcodes.ToList();

                foreach (var storedBarcode in storedBarcodes)
                {
                    Barcode barcode = new Barcode();

                    barcode.Barcode_ID = storedBarcode.Barcode_ID;
                    barcode.Inventory_ID = storedBarcode.Inventory_ID;
                    barcode.Barcode_Number = storedBarcode.Barcode_Number;
                    barcode.Barcode_Date = storedBarcode.Barcode_Date;

                    outputBarcode.Add(barcode);
                }

                return Ok(outputBarcode);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getFilteredBarcodes")]
        public IHttpActionResult getFilteredBarcodes(int id)
        {
            try
            {
                List<Barcode> outputBarcode = new List<Barcode>();
                var storedBarcodes = db.Barcodes.ToList();

                foreach (var storedBarcode in storedBarcodes)
                {
                    if (storedBarcode.Inventory_ID == id)
                    {
                        Barcode barcode = new Barcode();

                        barcode.Barcode_ID = storedBarcode.Barcode_ID;
                        barcode.Inventory_ID = storedBarcode.Inventory_ID;
                        barcode.Barcode_Number = storedBarcode.Barcode_Number;
                        barcode.Barcode_Date = storedBarcode.Barcode_Date;

                        outputBarcode.Add(barcode);
                    }
                }

                return Ok(outputBarcode);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("createBarcode")]
        public IHttpActionResult createBarcode(Barcode newBarcode)
        {
            try
            {
                db.Barcodes.Add(newBarcode);
                db.SaveChangesAsync();

                return Ok("Barcode Added");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("updateBarcode")]
        public IHttpActionResult updateBarcode(Barcode updateBarcode)
        {
            try
            {
                Barcode currentBarcode = new Barcode();
                currentBarcode = db.Barcodes.Where(z => z.Barcode_ID == updateBarcode.Barcode_ID).FirstOrDefault();

                currentBarcode.Barcode_Number = updateBarcode.Barcode_Number;

                db.SaveChangesAsync();

                return Ok("Barcode Updated!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("deleteBarcode")]
        public IHttpActionResult deleteBarcode(int id)
        {
            try
            {
                db.Barcodes.Remove(db.Barcodes.Single(z => z.Barcode_ID == id));

                db.SaveChangesAsync();

                return Ok("Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
