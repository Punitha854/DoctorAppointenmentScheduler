
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoctorSchedulerAPI.Models;

namespace DoctorSchedulerAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly MedicalContext _context;

        public DoctorsController(MedicalContext context)
        {
            _context = context;
        }

        // GET: api/Doctors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            List<Doctor> result = await _context.Doctors.ToListAsync();
            return result;// await _context.Doctors.ToListAsync();
        }

        // GET: api/Doctors/5
        [HttpGet]
        [Route("GetDoctor")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctor([FromQuery] string name,string Specialization,string Qualification)
        {
            List<Doctor> doctors = new List<Doctor>();

            //List<Doctor> doctors = await _context.Doctors.Where(x => string.IsNullOrEmpty(name) ? true : (x.FirstName + ' ' + x.LastName == name)
            //                           || string.IsNullOrEmpty(Specialization) ? true : x.Specialization == Specialization
            //                           || string.IsNullOrEmpty(Qualification) ? true : x.Qualification == Qualification).
            //                           ToListAsync<Doctor>(); 

            if (!string.IsNullOrEmpty(name))
            {
                doctors = await _context.Doctors.Where(x => (x.FirstName + ' ' + x.LastName == name)).ToListAsync<Doctor>();
                if (!string.IsNullOrEmpty(Specialization))
                    doctors= doctors.Where( x=> x.Specialization == Specialization).ToList();
                if (!string.IsNullOrEmpty(Qualification))
                    doctors = doctors.Where(x => x.Qualification == Qualification).ToList();
            }
            else if (!string.IsNullOrEmpty(Specialization))
            {
                doctors = await _context.Doctors.Where(x => x.Specialization == Specialization).ToListAsync<Doctor>(); 
                if (!string.IsNullOrEmpty(Qualification))
                    doctors = doctors.Where(x => x.Qualification == Qualification).ToList();
            }
            else if (!string.IsNullOrEmpty(Qualification))
            {
                doctors = await _context.Doctors.Where(x => x.Qualification == Qualification).ToListAsync<Doctor>();

            }

            if (doctors.Count == 0)
            {
                return NotFound();
            }

            return doctors;
        }

        

        // PUT: api/Doctors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(long id, Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        // POST: api/Doctors
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctor.Id }, doctor);
        }

        // DELETE: api/Doctors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(long id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return doctor;
        }

        private bool DoctorExists(long id)
        {
            return _context.Doctors.Any(e => e.Id == id);
        }
    }
}
