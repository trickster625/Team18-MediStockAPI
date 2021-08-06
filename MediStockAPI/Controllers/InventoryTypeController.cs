using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers
{
    public class InventoryTypesController : ApiController
    {

        //    MedistockInventoryTestEntities db = new MedistockInventoryTestEntities();

        //    [HttpGet]
        //    [Route("GetItemTypes")]
        //    public IHttpActionResult getItemTypes()
        //    {

        //        try
        //        {
        //            var types = db.InventoryTypes.ToList();
        //            List<InventoryType> typeList = new List<InventoryType>();

        //            foreach (var item in types)
        //            {

        //                InventoryType newInventoryType = new InventoryType();

        //                newInventoryType.TypeID = item.TypeID;
        //                newInventoryType.TypeDescription = item.TypeDescription;

        //                typeList.Add(newInventoryType);

        //            }

        //            return Ok(typeList);

        //        }
        //        catch (Exception)
        //        {
        //            return BadRequest();
        //        }

        //    }
        //}

    }

}