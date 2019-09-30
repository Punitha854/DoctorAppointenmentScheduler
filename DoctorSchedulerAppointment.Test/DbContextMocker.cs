using System;
using Microsoft.EntityFrameworkCore;

using DoctorSchedulerAPI.Models;

namespace DoctorSchedulerAppointment.Test
{
    public static class DbContextMocker
    {
        /// <summary>
        /// Create options for DbContext instance
        /// Create instance of DbContext
        /// Add entities in memory
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static MedicalContext  GetDoctorSchedulerDbContext(string dbName)
        {            
            var options = new DbContextOptionsBuilder<MedicalContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;            
            var dbContext = new MedicalContext(options); 
            dbContext.Seed();
            return dbContext;
        }
    }
}
