 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Employee.RegisterEmp
{
    public class RoleTypeController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getRoleTypes")]
        public IHttpActionResult getRoleTypes()
        {
            try
            {
                List<RoleType> outputTypes = new List<RoleType>();
                var storedTypes = db.RoleTypes.ToList();

                foreach (var storedType in storedTypes)
                {
                    RoleType type = new RoleType();
                    type.RoleType_ID = storedType.RoleType_ID;
                    type.RoleType_Description = storedType.RoleType_Description;
                    outputTypes.Add(type);
                }

                return Ok(outputTypes);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
