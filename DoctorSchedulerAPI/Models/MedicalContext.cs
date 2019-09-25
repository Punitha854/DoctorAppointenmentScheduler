using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoctorSchedulerAPI.Models;

namespace DoctorSchedulerAPI.Models
{
    public class MedicalContext:DbContext
    {
        public MedicalContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<DoctorSchedulerAPI.Models.Appointment> Appointment { get; set; }
    }
}
