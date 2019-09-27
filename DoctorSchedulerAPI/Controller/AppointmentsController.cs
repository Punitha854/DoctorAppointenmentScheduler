using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoctorSchedulerAPI.Models;
using System.Net;

namespace DoctorSchedulerAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly MedicalContext _context;

        public AppointmentsController(MedicalContext context)
        {
            _context = context;
        }

      
        // GET: api/Appointments/5
        [HttpGet]
        [Route("AppointmentByDate")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentByDate([FromQuery]string  doctorName,DateTime date)
        {
            List<Appointment> result = new List<Appointment>();
            try
            {
                if ( string.IsNullOrEmpty(doctorName) || date== null)
                {
                    var result1 = Content("Invalid Input");
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return result1;

                }
                result = await _context.Appointment.Include("Doctor").
                    Where(x => (x.Doctor.FirstName + ' ' + x.Doctor.LastName == doctorName)
                    && (x.AppFrom.Date == date.Date)).ToListAsync();
                if (result.Count == 0)
                {
                    var result1 = Content(" No appointments for the specified Date.Frée to book");
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    return Accepted();
                }
            }
            catch(Exception Ex)
            {
                var result1 = Content(" " + Ex.Message );
                HttpContext.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                return NoContent();
            }
            return result;
        }

        [HttpGet]
        [Route("AppointmentByDoctor")]
        public async Task<ActionResult<IEnumerable<object>>> GetAppointmentByDoctor([FromQuery]string doctorName)
        {
            if (string.IsNullOrEmpty(doctorName))
            {
                var result1 = Content("Invalid Input");
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return BadRequest();

            }
            var result = await _context.Appointment.Include("Doctor").
                Where(x => x.Doctor.FirstName + ' ' + x.Doctor.LastName == doctorName).
               Select(x => new { DoctorName = x.Doctor.FirstName, AppointmentFrom = x.AppFrom.ToString("dd-MM-yyyy HH:mm"), AppointmentTo = x.AppTo.ToString(), BookedPatient = x.Patient.FirstName }).
               ToListAsync();
            return result;
            
        }

        // PUT: api/Appointments/5
        [HttpPut]
        [Route("UpdateAppointment")]
        public async Task<IActionResult> PutAppointment([FromBody] Appointment appointment)
        {
            if (!AppointmentExists(appointment.Id))
            {
                return BadRequest();
            }           
            _context.Entry(appointment).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                //var result1 = Content("Updated Appointment");
                //HttpContext.Response.StatusCode = (int)HttpStatusCode.Accepted;
                //return result1;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(appointment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Accepted();
        }

        /// Api first verifies whether the Appointenment Time and Doctor are available at the time.
        // / If else then creates a new appointment
        [HttpPost]
        [Route("NewAppointment")]
        public async Task<ActionResult<Appointment>> PostAppointment([FromBody]Appointment appointment)
        {
            if (appointment == null)
                return BadRequest();
            bool isConflict = _context.Appointment.Any(e => e.AppFrom <= appointment.AppFrom && e.AppTo >= appointment.AppFrom && e.DoctorId != appointment.DoctorId);
            if (isConflict)
            {
                return Conflict("Exists already.Select another time frame");
            }
            _context.Appointment.Add(appointment);
            await _context.SaveChangesAsync();
                   

            return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
        }

       
        private bool AppointmentExists(long id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }
    }
}
