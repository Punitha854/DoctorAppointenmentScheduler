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
    public class PatientsController : ControllerBase
    {
        private readonly MedicalContext _context;

        public PatientsController(MedicalContext context)
        {
            _context = context;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(long id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        [HttpGet]
        [Route("PatientByName")]
        public async Task<ActionResult<Patient>> GetPatientByName(string name)
        {
            Patient patient = await _context.Patients.Where(x => (x.FirstName +' '+ x.LastName == name)).FirstOrDefaultAsync<Patient>();

            if (patient == null)
            {
                var result1 = Content("Patient not found");
                HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return BadRequest();
            }

            return patient;
        }
        // PUT: api/Patients/5
        [HttpPut]
        [Route("UpdatePatient")]
        public async Task<IActionResult> PutPatient(Patient patient)
        {
            if (!PatientExists(patient.Id))
            {
                return BadRequest();
            }
            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                //var result1 = Content("Updated Patient");
                //HttpContext.Response.StatusCode = (int)HttpStatusCode.Accepted;
                //return result1;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(patient.Id))
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

        // POST: api/Patients
        [HttpPost]
        [Route("NewPatient")]
        public async Task<ActionResult<Patient>> PostPatient([FromBody]Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]

        public async Task<ActionResult<Patient>> DeletePatient(long id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return patient;
        }

        private bool PatientExists(long id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
