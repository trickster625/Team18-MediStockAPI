using MediStockAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediStockAPI.Controllers
{
    public class FilterRoleTypesController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("GetFilteredRoleTypes")]
        public IHttpActionResult getFilteredRoleTypes(int RoleTypeID)
        {

            try
            {
                var roleTypes = db.RoleTypes.ToList();
                List<RoleTypeVM> RoleTypeList = new List<RoleTypeVM>();

                foreach (var type in roleTypes)
                {

                    if (type.RoleType_ID == RoleTypeID)
                    {
                        RoleTypeVM roleType = new RoleTypeVM();

                        roleType.RoleType_ID = type.RoleType_ID;
                        roleType.RoleType_Description = type.RoleType_Description;


                        RoleTypeList.Add(roleType);
                    }

                }

                return Ok(RoleTypeList);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }

}

