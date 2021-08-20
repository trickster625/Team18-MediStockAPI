using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Supplier
{
    public class SupplierController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getSuppliers")]
        public IHttpActionResult getSuppliers()
        {
            try
            {
                List<Models.Supplier> outputSuppliers = new List<Models.Supplier>();
                var suppliers = db.Suppliers.ToList();

                foreach (var supplier in suppliers)
                {
                    Models.Supplier newSupplier = new Models.Supplier();

                    newSupplier.Supplier_ID = supplier.Supplier_ID;
                    newSupplier.Supplier_Name = supplier.Supplier_Name;
                    newSupplier.Supplier_ContactPersonName = supplier.Supplier_ContactPersonName;
                    newSupplier.Supplier_ContactNumber = supplier.Supplier_ContactNumber;
                    newSupplier.Supplier_EmailAddress = supplier.Supplier_EmailAddress;

                    outputSuppliers.Add(newSupplier);
                }

                outputSuppliers = outputSuppliers.OrderBy(z => z.Supplier_Name).ToList();
                return Ok(outputSuppliers);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("createSupplier")]
        public IHttpActionResult createSupplier(Models.Supplier newSupplier)
        {
            try
            {
                db.Suppliers.Add(newSupplier);
                db.SaveChangesAsync();

                return Ok("Supplier Added");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("updateSupplier")]
        public IHttpActionResult updateSupplier(Models.Supplier updateSupplier)
        {
            try
            {
                Models.Supplier currentSupplier = new Models.Supplier();
                currentSupplier = db.Suppliers.Where(z => z.Supplier_ID == updateSupplier.Supplier_ID).FirstOrDefault();

                currentSupplier.Supplier_Name = updateSupplier.Supplier_Name;
                currentSupplier.Supplier_ContactPersonName = updateSupplier.Supplier_ContactPersonName;
                currentSupplier.Supplier_ContactNumber = updateSupplier.Supplier_ContactNumber;
                currentSupplier.Supplier_EmailAddress = updateSupplier.Supplier_EmailAddress;

                db.SaveChangesAsync();

                return Ok("Supplier Updated!");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("deleteSupplier")]
        public IHttpActionResult deleteSupplier(int id)
        {
            try
            {
                db.Suppliers.Remove(db.Suppliers.Single(z => z.Supplier_ID == id));

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
