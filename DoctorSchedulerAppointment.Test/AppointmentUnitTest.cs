using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoctorSchedulerAPI.Controller;
using DoctorSchedulerAPI.Models;
using Xunit;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DoctorSchedulerAppointment.Test
{

    public class AppointmentUnitTest
    {
        [Fact]
        public async Task TestAppointmentByDate()
        {
           
            List<Appointment> value = new List<Appointment>();
            var date = DateTime.Now;
            using (var dbContext = DbContextMocker.GetDoctorSchedulerDbContext(nameof(TestAppointmentByDate)))
            {
                var controller = new AppointmentsController(dbContext);
                var response = await controller.GetAppointmentByDate("Gurusaran Dharma", date);
                value = response.Value as List<Appointment>;                
            }           
            Assert.True(value.Count > 0);
        }

        [Fact]
        public async Task TestUpdateAppointment()
        {
            bool result = false;
            using (var dbContext = DbContextMocker.GetDoctorSchedulerDbContext(nameof(TestUpdateAppointment)))
            {
                var controller = new AppointmentsController(dbContext);
                Appointment apm = dbContext.Appointment.ToListAsync().Result.Find(x => x.Id == 1);
                if (apm != null)
                    apm.Description = "Unit Testing Change";
                var response = controller.PutAppointment(apm);
                result = response.IsCompletedSuccessfully;
               
            }
            
            Assert.True(result);
        }

        [Fact]
        public async Task TestNewAppointment()
        {
            bool result = false;           
            using (var dbContext = DbContextMocker.GetDoctorSchedulerDbContext(nameof(TestAppointmentByDate)))
            {
                var controller = new AppointmentsController(dbContext);
                Appointment apm = new Appointment();
                apm.Id = 5;
                apm.AppFrom = DateTime.Now.AddMinutes(120);
                apm.AppTo = DateTime.Now.AddMinutes(60);
                apm.DoctorId = 2;
                apm.PatientId = 2;
                var response  = controller.PostAppointment(apm);
                result = response.IsCompletedSuccessfully;
               // Assert.IsType<CreatedAtActionResult>(response.IsCompletedSuccessfully);

            }
            Assert.True(result);
        }

        [Fact]
        public async Task TestAppointmentByDoctor()
        {
            bool result = false;
            using (var dbContext = DbContextMocker.GetDoctorSchedulerDbContext(nameof(TestAppointmentByDoctor)))
            {
                var controller = new AppointmentsController(dbContext);
                var response = controller.GetAppointmentByDoctor("Steffan Bucksath");

                var doctor = response.Result.Value;
                result = doctor != null;
            }
            Assert.True(result);
        }
    }
}
