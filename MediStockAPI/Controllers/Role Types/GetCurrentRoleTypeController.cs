using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediStockAPI.Controllers.Role_Types
{
    public class GetCurrentRoleTypeController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("GetCurrentRoleTypes")]
        public IHttpActionResult getCurrentRoleTypes(int id)
        {

            try
            {
                var role = db.RoleTypes.ToList();
                List<RoleType> roleTypeList = new List<RoleType>();

                foreach (var i in role)
                {

                    RoleType Role = new RoleType();

                    if (i.RoleType_ID == id)
                    {

                        Role.RoleType_ID = i.RoleType_ID;
                        Role.RoleType_Description = i.RoleType_Description;

                    }

                    roleTypeList.Add(Role);

                }

                return Ok(roleTypeList);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}


