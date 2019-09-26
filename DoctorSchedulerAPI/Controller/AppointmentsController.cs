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

        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointment()
        {
            return await _context.Appointment.ToListAsync();
        }

        // GET: api/Appointments/5
        [HttpGet]
        [Route("AppointmentByDate")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointmentByDate([FromQuery]string  DoctorName,DateTime date)
        {
            List<Appointment> result = new List<Appointment>();
            try
            {
                if ( string.IsNullOrEmpty(DoctorName) || date== null)
                {
                    var result1 = Content("Invalid Input");
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return result1;

                }
                result = await _context.Appointment.Include("Doctor").
                    Where(x => (x.Doctor.FirstName + ' ' + x.Doctor.LastName == DoctorName)
                    && (x.AppFrom.Date == date.Date)).ToListAsync();
                if (result.Count == 0)
                {
                    var result1 = Content(" No appointments for the specified Date.Frée to book");
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                    return result1;
                }
            }
            catch(Exception Ex)
            {
                var result1 = Content(" " + Ex.Message );
                HttpContext.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                return result1;
            }
            return result;
        }

        [HttpGet]
        [Route("AppointmentByDoctor")]
        public async Task<ActionResult<IEnumerable<object>>> GetAppointmentByDoctor([FromQuery]string DoctorName)
        {
            if (string.IsNullOrEmpty(DoctorName))
            {
                var result1 = Content("Invalid Input");
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return result1;

            }
            var result = await _context.Appointment.Include("Doctor").
                Where(x => x.Doctor.FirstName + ' ' + x.Doctor.LastName == DoctorName).
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
                var result1 = Content("Updated Appointment");
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Accepted;
                return result1;
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

            return NoContent();
        }

        // POST: api/Appointments
        [HttpPost]
        [Route("NewAppointment")]
        public async Task<ActionResult<Appointment>> PostAppointment([FromBody]Appointment appointment)
        {
            _context.Appointment.Add(appointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment>> DeleteAppointment(long id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();

            return appointment;
        }

        private bool AppointmentExists(long id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }
    }
}
