using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediStockAPI.Models;

namespace MediStockAPI.Controllers.EmpShift
{
    public class ShiftController : ApiController
    {
        MediStock_DBEntities db = new MediStock_DBEntities();


        [HttpGet]
        [Route("getEmployeeShifts")]

        public IHttpActionResult getEmployeeShifts()
        {
            try
            {
                List<Shift> outputEmployeeShift = new List<Shift>();

                var storedEmployeeShifts = db.Shifts.ToList();

                foreach (var storedEmployeeShift in storedEmployeeShifts)
                {
                    Shift shift = new Shift();

                    shift.Shift_ID = storedEmployeeShift.Shift_ID;
                    shift.Employee_ID = storedEmployeeShift.Employee_ID;
                    shift.ShiftDate = storedEmployeeShift.ShiftDate;
                    shift.ShiftStartTime = storedEmployeeShift.ShiftStartTime;
                    shift.ShiftEndTime = storedEmployeeShift.ShiftEndTime;

                    outputEmployeeShift.Add(shift);
                }

                return Ok(outputEmployeeShift);

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }



        [HttpPost]
        [Route("CreateShift")]
        public IHttpActionResult CreateShift(Shift shift)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid data");
                }

                using (var ctx = new MediStock_DBEntities())
                {
                    ctx.Shifts.Add(new Shift()
                    {
                        Employee_ID = shift.Employee_ID,
                        ShiftDate = shift.ShiftDate,
                        ShiftEndTime = shift.ShiftEndTime,
                        ShiftStartTime = shift.ShiftStartTime,
                        Shift_ID = shift.Shift_ID

                    }); ;

                    ctx.SaveChanges();
                }
                return Ok("Shift Saved Succesfully!");
            }
            catch (Exception err)
            {

                return BadRequest(err.ToString());
            }
        }

        [HttpPut]
        [Route("UpdateShift")]
        public IHttpActionResult UpdateShift(Shift shift)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid shift");
            }

            using (var ctx = new MediStock_DBEntities())
            {
                var existingShift = ctx.Shifts.Where(s => s.Shift_ID == shift.Shift_ID).FirstOrDefault();

                if (existingShift != null)
                {
                    existingShift.Shift_ID = shift.Shift_ID;
                    existingShift.Employee_ID = shift.Employee_ID;
                    existingShift.ShiftDate = shift.ShiftDate;
                    existingShift.ShiftEndTime = shift.ShiftEndTime;
                    existingShift.ShiftStartTime = shift.ShiftStartTime;
                    

                    ctx.SaveChanges();

                }
                else
                {
                    return Ok(shift);
                }
            }
            return Ok("Saved Succesfully");
        }

        [HttpGet]
        [Route("getLastShift")]
        public IHttpActionResult getLastsShift()
        {
            try
            {
                var lastCall = db.Shifts.OrderByDescending(a => a.Shift_ID).FirstOrDefault().Shift_ID;
                return Ok(lastCall);
            }
            catch (Exception err)
            {
                return BadRequest("last Shift ID ERROR:" + err.ToString());
                throw;
            }

        }


    }

}
