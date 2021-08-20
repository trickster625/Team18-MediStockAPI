using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;
using System.Web.Http.Cors;

namespace MediStockAPI.Controllers
{
    public class VehicleController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();

        [HttpGet]
        [Route("getVehicles")]

        public IHttpActionResult getVehicles()
        {
            try
            {
                List<VehicleVM> outputVehicles = new List<VehicleVM>();

                var storedVehicles = db.Vehicles.ToList();
                var storedVehicleTypes = db.VehicleTypes.ToList();

                foreach (var storedVehicle in storedVehicles)
                {
                    VehicleVM vehicle = new VehicleVM();

                    vehicle.Vehicle_ID = storedVehicle.Vehicle_ID;
                    vehicle.VehicleType_ID = storedVehicle.VehicleType_ID;
                    vehicle.Vehicle_Name = storedVehicle.Vehicle_Name;

                    foreach (var storedVehicleType in storedVehicleTypes)
                    {
                        if (storedVehicle.VehicleType_ID == storedVehicleType.VehicleType_ID)
                        {
                            vehicle.VehicleType_Description = storedVehicleType.VehicleType_Description;
                        }
                    }

                    outputVehicles.Add(vehicle);
                }

                return Ok(outputVehicles);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getFilteredVehicles")]
        public IHttpActionResult getFilteredVehicles(string searchName, int searchTypeID)
        {

            try
            {
                var vehicles = db.Vehicles.ToList();
                var vehicletypes = db.VehicleTypes.ToList();
                List<VehicleVM> VehicleList = new List<VehicleVM>();

                foreach (var vehicle in vehicles)
                {

                    if (vehicle.Vehicle_Name == searchName && vehicle.VehicleType_ID == searchTypeID)
                    {
                        VehicleVM vehicleItem = new VehicleVM();

                        vehicleItem.Vehicle_ID = vehicle.Vehicle_ID;
                        vehicleItem.Vehicle_Name = vehicle.Vehicle_Name;
                        vehicleItem.VehicleType_ID = vehicle.VehicleType_ID;

                        foreach (var vehicletype in vehicletypes)
                        {
                            if (vehicle.VehicleType_ID == vehicletype.VehicleType_ID)
                            {
                                vehicleItem.VehicleType_Description = vehicletype.VehicleType_Description;
                            }
                        }

                        VehicleList.Add(vehicleItem);
                    }

                }

                return Ok(VehicleList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getCurrentVehicle")]
        public IHttpActionResult getCurrentVehicle(int id)
        {

            try
            {
                var vehicles = db.Vehicles.ToList();
                List<VehicleVM> VehicleList = new List<VehicleVM>();
                VehicleVM currentVehicle = new VehicleVM();

                foreach (var vehicle in vehicles)
                {

                    if (vehicle.Vehicle_ID== id)
                    {
                        currentVehicle.Vehicle_ID = id;
                        currentVehicle.Vehicle_Name = vehicle.Vehicle_Name;
                        currentVehicle.VehicleType_ID = vehicle.VehicleType_ID; 
                        return Ok(currentVehicle);
                    }

                }

                return Ok("No Match Found");
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("createVehicle")]
        public IHttpActionResult createVehicle(Models.Vehicle newVehicle)
        {
            try
            {
                db.Vehicles.Add(newVehicle);
                db.SaveChangesAsync();

                return Ok("Vehicle Added!");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        [Route("updateVehicle")]
        public IHttpActionResult updateVehicle(Models.Vehicle updateVehicle)
        {
            try
            {
                Models.Vehicle currentVehicle = new Models.Vehicle();
                currentVehicle = db.Vehicles.Where(z => z.Vehicle_ID == updateVehicle.Vehicle_ID).FirstOrDefault();

                currentVehicle.VehicleType_ID = updateVehicle.VehicleType_ID;
                currentVehicle.Vehicle_Name = updateVehicle.Vehicle_Name;

                db.SaveChangesAsync();

                return Ok("Vehicle Updated!");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("deleteVehicle")]
        public IHttpActionResult deleteVehicle(int id)
        {
            try
            {
                db.Vehicles.Remove(db.Vehicles.Single(z => z.Vehicle_ID == id));

                db.SaveChangesAsync();

                return Ok("Vehicle Deleted!");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
