using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers
{
    public class RoleTypesController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("GetRoleTypes")]
        public IHttpActionResult getRoleTypes()
        {

            try
            {
                var roleTypes = db.RoleTypes.ToList();
                List<RoleType> RoleTypeList = new List<RoleType>();

                foreach (var type in roleTypes)
                {

                    RoleType RoleTypes = new RoleType();

                    RoleTypes.RoleType_ID = type.RoleType_ID;
                    RoleTypes.RoleType_Description = type.RoleType_Description;

                    RoleTypeList.Add(RoleTypes);

                }

                return Ok(RoleTypeList);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("PostCreateRoleType")]
        public IHttpActionResult PostCreateRoleType(RoleType roleType)
        {

            try
            {
                db.RoleTypes.Add(roleType);
                db.SaveChangesAsync();

                return Ok("Role Added");
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("DeleteRoleType")]
        public IHttpActionResult deleteRoleType(int id)
        {
            try
            {
                db.RoleTypes.Remove(db.RoleTypes.Single(z => z.RoleType_ID == id));

                db.SaveChangesAsync();

                return Ok("Deleted");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateRoleType")]
        public IHttpActionResult updateRoleType(RoleType updatedRoleType)

        {
            try
            {
                RoleType currentRoleType = new RoleType();
                currentRoleType = db.RoleTypes.Where(z => z.RoleType_ID == updatedRoleType.RoleType_ID).FirstOrDefault();


                currentRoleType.RoleType_ID = updatedRoleType.RoleType_ID;
                currentRoleType.RoleType_Description = updatedRoleType.RoleType_Description;

                db.SaveChangesAsync();

                return Ok(currentRoleType);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}