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
    public class PatientUnitTest
    {
        /// <summary>
        /// Unit testing for getting an patient by the name filter
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestGetPatientByName()
        {
            bool result = false;       
            using (var dbContext = DbContextMocker.GetDoctorSchedulerDbContext(nameof(TestGetPatientByName)))
            {
                var controller = new PatientsController(dbContext);
                var response =  controller.GetPatientByName("Guruswamy Ramaiah");
                var value = response.Result;
                result = value.Value.LastName == "Ramaiah";
            }
            Assert.True(result);

        }
        /// <summary>
        /// Unit testing for updating existing patient
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestUpdatePatient()
        {
            bool result = false;
            using (var dbContext = DbContextMocker.GetDoctorSchedulerDbContext(nameof(TestUpdatePatient)))
            {
                var controller = new PatientsController(dbContext);
                Patient pp = dbContext.Patients.ToListAsync().Result.Find(x => x.Id == 2);// FindAsync(2); 
                pp.PhoneNumber = "4556";
                pp.DateOfBirth = DateTime.Now.AddYears(-40);
                var response = controller.PutPatient(pp);              
                result = response.IsCompletedSuccessfully;
            }
            Assert.True(result);
        }

        /// <summary>
        /// Units test for creating new patient
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestNewPatient()
        {
            bool result = false;
            using (var dbContext = DbContextMocker.GetDoctorSchedulerDbContext(nameof(TestNewPatient)))
            {
                var controller = new PatientsController(dbContext);
                Patient pp = new Patient();
                pp.Id = 6;
                pp.DiseaseId = 2;
                pp.Email = "TestNewPatient2@yahoo.com";
                pp.FirstName = "FirstName";
                pp.LastName = "Periscope";
                pp.PhoneNumber = "123456";
                var response = controller.PostPatient(pp);
                // long value = response.Result.Value.Id;
                result = response.IsCompletedSuccessfully;// &&  value > 0;
            }
            Assert.True(result);

        }
    }
}
