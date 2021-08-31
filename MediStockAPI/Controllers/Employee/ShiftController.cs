using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpGet]
        [Route("getFilteredEmployeeShifs")]
        public IHttpActionResult getFilteredEmployeeShifts(int ShiftID)
        {

            try
            {
                var shifts = db.Shifts.ToList();
                List<Shift> EmployeeShiftList = new List<Shift>();

                foreach (var shift in shifts)
                {

                    if (shift.Shift_ID == ShiftID)
                    {
                        Shift employeeShift = new Shift();

                        employeeShift.Shift_ID = shift.Shift_ID;
                        employeeShift.Employee_ID = shift.Employee_ID;
                        employeeShift.ShiftDate = (DateTime)shift.ShiftDate;
                        employeeShift.ShiftStartTime = (TimeSpan)shift.ShiftStartTime;
                        employeeShift.ShiftEndTime = (TimeSpan)shift.ShiftEndTime;

                        EmployeeShiftList.Add(employeeShift);
                    }

                }

                return Ok(EmployeeShiftList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("createShift")]
        public IHttpActionResult createShift(Models.Shift newShift)
        {
            try
            {
                db.Shifts.Add(newShift);
                db.SaveChangesAsync();

                return Ok("Shift Added!");
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

    }
}

