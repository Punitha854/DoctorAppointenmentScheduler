using System;
using Microsoft.EntityFrameworkCore;

using DoctorSchedulerAPI.Models;

namespace DoctorSchedulerAppointment.Test
{
    public static class DbContextMocker
    {
        public static MedicalContext  GetDoctorSchedulerDbContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<MedicalContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new MedicalContext(options);
            

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
