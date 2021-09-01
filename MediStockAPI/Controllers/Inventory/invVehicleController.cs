﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.Inventory
{
    public class invVehicleController : ApiController
    {

        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getInvVehicles")]
        public IHttpActionResult getInvVehicles()
        {
            try
            {
                List<Models.Vehicle> outputVehicles = new List<Models.Vehicle>();
                var storedVehicles = db.Vehicles.ToList();

                foreach (var storedVehicle in storedVehicles)
                {
                    Models.Vehicle vehicle = new Models.Vehicle();

                    vehicle.Vehicle_ID = storedVehicle.Vehicle_ID;
                    vehicle.Vehicle_Name = storedVehicle.Vehicle_Name;

                    outputVehicles.Add(vehicle);
                }

                return Ok(outputVehicles);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
