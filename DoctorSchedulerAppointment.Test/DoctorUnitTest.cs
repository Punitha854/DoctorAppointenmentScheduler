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
    public class DoctorUnitTest
    {
        [Fact]
        public async Task TestGetDoctor()
        {
            bool result = false;                        
            using (var dbContext = DbContextMocker.GetDoctorSchedulerDbContext(nameof(TestGetDoctor)))
            {
                var controller = new DoctorsController(dbContext);
                var response = await controller.GetDoctor("Steffan Bucksath", string.Empty ,"MS");
                List<Doctor>  value = response.Value as List<Doctor>;
                result = value.Count > 0;
            }
            Assert.True(result);
        }
    }
}
