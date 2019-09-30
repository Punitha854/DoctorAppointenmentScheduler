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

        /// <summary>
        ///  Get the Patient resord based on the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// return a  first encounterd patient with the  given name as parameter
        /// </summary>
        /// <param name="name"></param>
        /// <returns> Return a singe  record of patient object</returns>
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
       /// <summary>
       /// Updates an existing patient record
       /// </summary>
       /// <param name="patient"></param>
       /// <returns></returns>
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

       /// <summary>
       ///  On sigining in , a new patients enters his/her details and creates a new patient object 
       /// </summary>
       /// <param name="patient"></param>
       /// <returns> The Update status of the new Patient in the database</returns>
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
