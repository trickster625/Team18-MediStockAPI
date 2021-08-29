using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediStockAPI.Controllers.Employee
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

                var storedEmployeeShifts = db.Shift.ToList();
                
                foreach (var storedEmployeeShifts in storedEmployeeShift)
                {
                    Shift shift = new Shift();

                    shift.Shift_ID = storedEmployeeShifts.Shift_ID;
                    shift.Employee_ID = storedEmployeeShifts.Employee_ID;
                    shift.ShiftDate = storedEmployeeShifts.ShiftDate;
                    shift.ShiftStartTime = storedEmployeeShifts.ShiftStartTime;
                    shift.ShiftEndTime = storedEmployeeShifts.ShiftEndTime;

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
        public IHttpActionResult getFilteredEmployeeShifts(string searchEmployee_Name, int searchShiftDate)
        {

            try
            {
                var EmployeeShifts = db.Shift.ToList();

                List<Shift> EmployeeShiftList = new List<Shift>();

                foreach (var storedEmployees in employee)
                {

                    if (EmployeeShifts.Employee_Name == searchEmployee_Name && EmployeeShifts.ShiftDate == searchShiftDate)
                    {
                        Shift shift = new Shift();

                        shift.Shift_ID = storedEmployeeShifts.Shift_ID;
                        shift.Employee_ID = storedEmployeeShifts.Employee_ID;
                        shift.ShiftDate = storedEmployeeShifts.ShiftDate;
                        shift.ShiftStartTime = storedEmployeeShifts.ShiftStartTime;
                        shift.ShiftEndTime = storedEmployeeShifts.ShiftEndTime;

                        EmployeeShiftList.Add(shift);
                    }

                }

                return Ok(EmployeeShiftsList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("createShift")]
        public IHttpActionResult createShift(CreateShift newShift)
        {
            try
            {
                db.Shift.Add(newShift);
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
