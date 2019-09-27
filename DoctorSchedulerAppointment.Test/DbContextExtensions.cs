using DoctorSchedulerAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctorSchedulerAppointment.Test
{
    public static class DbContextExtensions
    {
        public static void Seed(this MedicalContext dbContext)
        {
            dbContext.Appointment.Add(
                new Appointment
                {
                    Id = 1,
                    AppFrom = DateTime.Now.AddHours(-2),
                    AppTo = DateTime.Now.AddMinutes(-100),
                    PatientId = 2,
                    DoctorId = 1,
                    Description = "Unit testing"

                });
            dbContext.Appointment.Add(
                new Appointment
                {
                    Id = 2,
                    AppFrom = DateTime.Now.AddHours(-3),
                    AppTo = DateTime.Now.AddMinutes(-140),
                    PatientId = 1,
                    DoctorId = 2,
                    Description = "Unit testing"

                });
            dbContext.Appointment.Add(
                new Appointment
                {
                    Id = 3,
                    AppFrom = DateTime.Now.AddDays(-2),
                    AppTo = DateTime.Now.AddDays(-2).AddMinutes(-40),
                    PatientId = 3,
                    DoctorId = 3,
                    Description = "Unit testing"

                });

            dbContext.Doctors.Add(
               new Doctor
               {
                   Id = 1,
                   FirstName = "Gurusaran",
                   LastName = "Dharma",
                   Specialization = "Cardiologist",
                   Qualification = "MD",
                   PhoneNumber = "2345546575674"

               });
            dbContext.Doctors.Add(
               new Doctor
               {
                   Id = 2,
                   FirstName = "Steffan",
                   LastName = "Bucksath",
                   Specialization = "General",
                   Qualification = "MS",
                   PhoneNumber = "4945546575674"

               });
            dbContext.Doctors.Add(
               new Doctor
               {
                   Id = 3,
                   FirstName = "Florian",
                   LastName = "Muller",
                   Specialization = "Neuroligist",
                   Qualification = "MBBS",
                   PhoneNumber = "23444444475674"

               });
            dbContext.Doctors.Add(
               new Doctor
               {
                   Id = 4,
                   FirstName = "Michael",
                   LastName = "Muller",
                   Specialization = "Dietician",
                   Qualification = "MBBS",
                   PhoneNumber = "2347775674"

               });
            dbContext.Patients.Add(
               new Patient
               {
                   Id = 1,
                   FirstName = "Guruswamy",
                   LastName = "Ramaiah",
                   DiseaseId = 1                 

               });
           dbContext.Patients.Add(
           new Patient
            {
                Id = 2,
                FirstName = "Thorsten",
                LastName = "Strobel",
                DiseaseId = 2

            });
            dbContext.Patients.Add(
          new Patient
          {
              Id = 3,
              FirstName = "Vladimir",
              LastName = "Sajdl",
              DiseaseId = 1

          });
            dbContext.Diseases.Add(
               new Disease
               {
                   Id = 1,
                   name  = "Cardiac Arrest",
                   Description = " Heart Problem"
                 

               });
            dbContext.Diseases.Add(
              new Disease
              {
                  Id = 2,
                  name = "Kidney Infection",
                  Description = " Kidney Problem"


              });
            dbContext.Diseases.Add(
              new Disease
              {
                  Id = 3,
                  name = "Obesity",
                  Description = "Too much weight"


              });
            dbContext.SaveChangesAsync();

        }
    }
}
